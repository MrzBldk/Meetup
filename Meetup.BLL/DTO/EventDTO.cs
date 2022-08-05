namespace Meetup.BLL.DTO
{
    public class EventDTO : EntityDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public Guid OrganizerId { get; set; }
        public OrganizerDTO Organizer { get; set; }
        public Guid? SpeakerId { get; set; }
        public SpeakerDTO Speaker { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
    }
}
