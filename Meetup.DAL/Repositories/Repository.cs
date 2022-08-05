using Meetup.DAL.Context;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        internal MeetupContext Context;
        internal DbSet<TEntity> DbSet;

        public Repository(MeetupContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Find()
        {
            return DbSet.AsQueryable();
        }
        public virtual TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }
        public virtual TEntity FindLast()
        {
            return DbSet.OrderByDescending(TEntity => TEntity.Created).First();
        }
        public virtual void InsertOrUpdate(TEntity entity)
        {
            if (entity.IsNew)
                DbSet.Add(entity);
            else
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }
        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
    }
}
