namespace Meetup.DAL.Entities
{
    public class Organizer : Entity
    {
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
