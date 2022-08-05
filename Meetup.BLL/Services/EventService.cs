using AutoMapper;
using Meetup.BLL.DTO;
using Meetup.BLL.Services.Interfaces;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories.Interfaces;

namespace Meetup.BLL.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public List<EventDTO> Get()
        {
            var events = UnitOfWork.EventRepository.Find().ToList();
            return Mapper.Map<List<EventDTO>>(events);
        }
        public EventDTO GetbyId(Guid id)
        {
            return Mapper.Map<EventDTO>(UnitOfWork.EventRepository.FindById(id));
        }
        public EventDTO GetLast()
        {
            return Mapper.Map<EventDTO>(UnitOfWork.EventRepository.FindLast());
        }
        public void Save(EventDTO model)
        {
            if (model.IsNew)
            {
                var entity = Mapper.Map<Event>(model);
                UnitOfWork.EventRepository.InsertOrUpdate(entity);
            }
            else
            {
                var toEdit = UnitOfWork.EventRepository.FindById(model.Id);
                Mapper.Map(model, toEdit);
                UnitOfWork.EventRepository.InsertOrUpdate(toEdit);
            }
            UnitOfWork.Commit();
        }
        public void Delete(Guid id)
        {
            var toDelete = UnitOfWork.EventRepository.FindById(id);
            UnitOfWork.EventRepository.Delete(toDelete);
            UnitOfWork.Commit();
        }
    }
}
