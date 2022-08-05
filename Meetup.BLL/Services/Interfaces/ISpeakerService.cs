using Meetup.BLL.DTO;

namespace Meetup.BLL.Services.Interfaces
{
    public interface ISpeakerService
    {
        List<SpeakerDTO> Get();
        SpeakerDTO GetbyId(Guid id);
        SpeakerDTO GetLast();
        void Save(SpeakerDTO model);
        void Delete(Guid id);
    }
}
