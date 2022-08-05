using AutoMapper;
using Meetup.BLL.DTO;
using Meetup.DAL.Entities;

namespace Meetup.BLL.Mappers
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<EventDTO, Event>();
            CreateMap<OrganizerDTO, Organizer>();
            CreateMap<SpeakerDTO, Speaker>();
        }
        public override string ProfileName => "DtoToDomainMappingProfile";
    }
}
