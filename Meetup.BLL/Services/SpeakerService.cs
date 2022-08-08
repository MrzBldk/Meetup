using AutoMapper;
using Meetup.BLL.DTO;
using Meetup.BLL.Services.Interfaces;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories.Interfaces;

namespace Meetup.BLL.Services
{
    public class SpeakerService : BaseService, ISpeakerService
    {
        public SpeakerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public List<SpeakerDTO> Get()
        {
            var events = UnitOfWork.SpeakerRepository.Find().ToList();
            return Mapper.Map<List<SpeakerDTO>>(events);
        }
        public SpeakerDTO GetbyId(Guid id)
        {
            return Mapper.Map<SpeakerDTO>(UnitOfWork.SpeakerRepository.FindById(id));
        }
        public SpeakerDTO GetLast()
        {
            return Mapper.Map<SpeakerDTO>(UnitOfWork.SpeakerRepository.FindLast());
        }
        public void Save(SpeakerDTO model)
        {
            if (model.IsNew)
            {
                var entity = Mapper.Map<Speaker>(model);
                UnitOfWork.SpeakerRepository.InsertOrUpdate(entity);
            }
            else
            {
                var toEdit = UnitOfWork.SpeakerRepository.FindById(model.Id);
                Mapper.Map(model, toEdit);
                UnitOfWork.SpeakerRepository.InsertOrUpdate(toEdit);
            }
            UnitOfWork.Commit();
        }
        public void Delete(Guid id)
        {
            var toDelete = UnitOfWork.SpeakerRepository.FindById(id);
            UnitOfWork.SpeakerRepository.Delete(toDelete);
            UnitOfWork.Commit();
        }

    }
}
