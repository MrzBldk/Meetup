using Meetup.DAL.Context;
using Meetup.DAL.Entities;
using Meetup.DAL.Repositories.Interfaces;

namespace Meetup.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly MeetupContext _context;

        private IRepository<Event> _eventRepository;
        private IRepository<Organizer> _organizerRepository;
        private IRepository<Speaker> _speakerRepository;

        public UnitOfWork(MeetupContext context)
        {
            _context = context;
        }

        public IRepository<Event> EventRepository => _eventRepository ??= new Repository<Event>(_context);
        public IRepository<Organizer> OrganizerRepository => _organizerRepository ??= new Repository<Organizer>(_context);
        public IRepository<Speaker> SpeakerRepository => _speakerRepository ??= new Repository<Speaker>(_context);

        public bool Commit()
        {
            return _context.SaveChanges() != 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
