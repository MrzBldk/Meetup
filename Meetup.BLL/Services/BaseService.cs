using AutoMapper;
using Meetup.BLL.Services.Interfaces;
using Meetup.DAL.Repositories.Interfaces;

namespace Meetup.BLL.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        public IMapper Mapper { get; }

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
