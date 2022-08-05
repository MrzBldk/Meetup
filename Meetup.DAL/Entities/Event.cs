namespace Meetup.DAL.Entities
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public Guid? SpeakerId { get; set; }
        public Speaker Speaker { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
    }
}
