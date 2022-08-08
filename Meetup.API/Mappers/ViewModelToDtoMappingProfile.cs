using AutoMapper;
using Meetup.API.Models;
using Meetup.BLL.DTO;

namespace Meetup.API.Mappers
{
    public class ViewModelToDtoMappingProfile : Profile
    {
        public ViewModelToDtoMappingProfile()
        {
            CreateMap<EventViewModel, EventDTO>()
                .ForMember(p => p.Organizer, opts => opts.Ignore())
                .ForMember(p => p.Speaker, opts => opts.Ignore());
        }

        public override string ProfileName => "ViewModelToDtoMappingProfile";
    }
}
