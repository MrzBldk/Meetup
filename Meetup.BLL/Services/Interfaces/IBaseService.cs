using AutoMapper;

namespace Meetup.BLL.Services.Interfaces
{
    public interface IBaseService
    {
        IMapper Mapper { get; }
    }
}
