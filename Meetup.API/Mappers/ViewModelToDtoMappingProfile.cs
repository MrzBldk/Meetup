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
            CreateMap<CreateEventViewModel, EventDTO>()
                .ForMember(p => p.Id, opts => opts.MapFrom(x => Guid.Empty));
            CreateMap<EditEventViewModel, EventDTO>();
        }

        public override string ProfileName => "ViewModelToDtoMappingProfile";
    }
}
