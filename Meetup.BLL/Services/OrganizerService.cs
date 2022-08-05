using AutoMapper;
using Meetup.BLL.DTO;
using Meetup.BLL.Services.Interfaces;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories.Interfaces;

namespace Meetup.BLL.Services
{
    internal class OrganizerService : BaseService, IOrganizerService
    {
        public OrganizerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public List<OrganizerDTO> Get()
        {
            var events = UnitOfWork.OrganizerRepository.Find().ToList();
            return Mapper.Map<List<OrganizerDTO>>(events);
        }
        public OrganizerDTO GetbyId(Guid id)
        {
            return Mapper.Map<OrganizerDTO>(UnitOfWork.OrganizerRepository.FindById(id));
        }
        public OrganizerDTO GetLast()
        {
            return Mapper.Map<OrganizerDTO>(UnitOfWork.OrganizerRepository.FindLast());
        }
        public void Save(OrganizerDTO model)
        {
            if (model.IsNew)
            {
                var entity = Mapper.Map<Organizer>(model);
                UnitOfWork.OrganizerRepository.InsertOrUpdate(entity);
            }
            else
            {
                var toEdit = UnitOfWork.OrganizerRepository.FindById(model.Id);
                Mapper.Map(model, toEdit);
                UnitOfWork.OrganizerRepository.InsertOrUpdate(toEdit);
            }
            UnitOfWork.Commit();
        }
        public void Delete(Guid id)
        {
            var toDelete = UnitOfWork.OrganizerRepository.FindById(id);
            UnitOfWork.OrganizerRepository.Delete(toDelete);
            UnitOfWork.Commit();
        }
    }
}
