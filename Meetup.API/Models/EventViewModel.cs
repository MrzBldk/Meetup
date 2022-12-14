namespace Meetup.API.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid OrganizerId { get; set; }
        public string Organizer { get; set; }
        public Guid? SpeakerId { get; set; }
        public string? Speaker { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
    }
}
