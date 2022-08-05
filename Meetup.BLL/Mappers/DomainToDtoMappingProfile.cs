using AutoMapper;
using Meetup.BLL.DTO;
using Meetup.DAL.Entities;

namespace Meetup.BLL.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<Organizer, OrganizerDTO>();
            CreateMap<Speaker, SpeakerDTO>();
        }
        public override string ProfileName => "DomainToDtoMappingProfile";
    }
}
