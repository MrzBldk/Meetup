namespace Meetup.DAL.Entities
{
    public class Speaker : Entity
    {
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
