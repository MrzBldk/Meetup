using Meetup.BLL.DTO;

namespace Meetup.BLL.Services.Interfaces
{
    public interface IEventService
    {
        List<EventDTO> Get();
        EventDTO GetbyId(Guid id);
        EventDTO GetLast();
        void Save(EventDTO model);
        void Delete(Guid id);
    }
}
