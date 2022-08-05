using Meetup.DAL.Entities;

namespace Meetup.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Event> EventRepository { get; }
        public IRepository<Organizer> OrganizerRepository { get; }
        public IRepository<Speaker> SpeakerRepository { get; }
        bool Commit();
    }
}
