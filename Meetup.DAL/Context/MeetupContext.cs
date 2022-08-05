using Meetup.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.Context
{
    public class MeetupContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().Property(b => b.Created).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Speaker>().Property(b => b.Created).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Organizer>().Property(b => b.Created).HasDefaultValueSql("getdate()");

            Guid organizerGuid = Guid.NewGuid();

            modelBuilder.Entity<Organizer>().HasData(new Organizer() { Id = organizerGuid, Name = "Organizer" });

            modelBuilder.Entity<Speaker>().HasData(new Speaker() { Id = Guid.NewGuid(), Name = "Speaker" });

            modelBuilder.Entity<Event>().HasData(
                new Event() { Id = Guid.NewGuid(), Title = "Event 1", OrganizerId = organizerGuid, Date = DateTime.Now, Place = "Place 1" },
                new Event() { Id = Guid.NewGuid(), Title = "Event 2", OrganizerId = organizerGuid, Date = DateTime.Now, Place = " Place 2" },
                new Event() { Id = Guid.NewGuid(), Title = "Event 3", OrganizerId = organizerGuid, Date = DateTime.Now, Place = "Place 3" });

            modelBuilder.Entity<Event>().Navigation(e => e.Organizer).AutoInclude();
            modelBuilder.Entity<Event>().Navigation(e => e.Speaker).AutoInclude();
        }
    }
}
