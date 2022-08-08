using AutoMapper;
using Meetup.API.Models;
using Meetup.BLL.DTO;
using Meetup.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private IMapper _mapper;
        private IEventService _eventService;
        public EventsController(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>All events</returns>
        /// <response code="200">Returns all the events</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<EventViewModel>>(_eventService.Get()));
        }


        /// <summary>
        /// Gets a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific event</returns>
        /// <response code="200">Returns the specific event</response>
        /// <response code="404">If the event is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] Guid id)
        {
            EventDTO dto = _eventService.GetbyId(id);
            if (dto is null) return NotFound(new { message = "Event not found" });
            return Ok(_mapper.Map<EventViewModel>(dto));
        }

        /// <summary>
        /// Creates an event.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created event</returns>
        ///<remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///         "title": "Event",
        ///         "description": "description",
        ///         "organizerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "speakerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "date": "2022-08-08T16:23:26.800Z",
        ///         "place": "place"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created event</response>
        /// <response code="400">If the event is incorrect</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromServices] IOrganizerService organizerService, [FromServices] ISpeakerService speakerService,
            [FromBody] EventViewModel model)
        {
            if (model.Id != Guid.Empty)
                ModelState.AddModelError("Id", "Id must be empty");

            if (organizerService.GetbyId(model.OrganizerId) is null)
                ModelState.AddModelError("OrganizerId", "Incorrect organizer id");

            if (model.SpeakerId.HasValue && speakerService.GetbyId(model.OrganizerId) is null)
                ModelState.AddModelError("SpeakerId", "Incorrect speaker id");

            if (ModelState.IsValid)
            {
                EventDTO dto = _mapper.Map<EventDTO>(model);
                _eventService.Save(dto);
                model = _mapper.Map<EventViewModel>(_eventService.GetLast());
                return Created($"/api/Events/{model.Id}", model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Edits an event.
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///         "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///         "title": "Event",
        ///         "description": "description",
        ///         "organizerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "speakerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "date": "2022-08-08T16:23:26.800Z",
        ///         "place": "place"
        ///     }
        ///
        /// </remarks>
        /// <response code="204"></response>
        /// <response code="400">If the event is incorrect</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromServices] IOrganizerService organizerService, [FromServices] ISpeakerService speakerService,
            [FromBody] EventViewModel model)
        {
            if (_eventService.GetbyId(model.Id) is null)
                ModelState.AddModelError("Id", "Incorrect id");

            if (organizerService.GetbyId(model.OrganizerId) is null)
                ModelState.AddModelError("OrganizerId", "Incorrect organizer id");

            if (model.SpeakerId.HasValue && speakerService.GetbyId(model.OrganizerId) is null)
                ModelState.AddModelError("SpeakerId", "Incorrect speaker id");

            if (ModelState.IsValid)
            {
                EventDTO dto = _mapper.Map<EventDTO>(model);
                _eventService.Save(dto);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Deletes a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204"></response>
        /// <response code="404">If the event is not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromQuery] Guid id)
        {
            if (_eventService.GetbyId(id) is null)
                return NotFound();

            _eventService.Delete(id);
            return NoContent();
        }
    }
}
