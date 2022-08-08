using AutoMapper;
using Meetup.API.Models;
using Meetup.BLL.DTO;

namespace Meetup.API.Mappers
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<EventDTO, EventViewModel>()
                .ForMember(p => p.Organizer, opts => opts.MapFrom(p => p.Organizer.Name))
                .ForMember(p => p.Speaker, opts => opts.MapFrom(p => p.Speaker.Name));
        }

        public override string ProfileName => "DtoToViewModelMappingProfile";
    }
}
