using Meetup.DAL.Entities;

namespace Meetup.DAL.Repositories.Interfaces
{
    public interface IRepository <TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Find();
        TEntity FindById(Guid id);
        TEntity FindLast();
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
