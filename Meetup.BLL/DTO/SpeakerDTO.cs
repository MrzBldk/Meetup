namespace Meetup.BLL.DTO
{
    public class SpeakerDTO : EntityDTO
    {
        public string Name { get; set; }
        public ICollection<EventDTO> Events { get; set; }
    }
}
