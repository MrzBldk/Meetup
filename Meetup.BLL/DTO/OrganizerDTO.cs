namespace Meetup.BLL.DTO
{
    public class OrganizerDTO : EntityDTO
    {
        public string Name { get; set; }
        public ICollection<EventDTO> Events { get; set; }
    }
}
