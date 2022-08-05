using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.DAL.Entities
{
    public class Entity
    {
        private readonly Guid _initialId;

        public virtual bool IsNew => Id == _initialId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public DateTime Created { get; set; }

        public Entity()
        {
            _initialId = Guid.Empty;
            Id = _initialId;
        }
    }
}
