using Meetup.DAL.Entities;

namespace Meetup.DAL.Repositories.Interfaces
{
    public interface IRepository <TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Find();
        ValueTask<TEntity> FindById(Guid id);
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
