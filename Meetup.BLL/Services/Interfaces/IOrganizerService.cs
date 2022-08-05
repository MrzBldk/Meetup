using Meetup.BLL.DTO;

namespace Meetup.BLL.Services.Interfaces
{
    public interface IOrganizerService
    {
        List<OrganizerDTO> Get();
        OrganizerDTO GetbyId(Guid id);
        OrganizerDTO GetLast();
        void Save(OrganizerDTO model);
        void Delete(Guid id);
    }
}
