namespace Meetup.BLL.DTO
{
    public class EntityDTO
    {
        public virtual bool IsNew => Id == Guid.Empty;
        public virtual Guid Id { get; set; }
    }
}
