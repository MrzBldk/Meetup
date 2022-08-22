using System.ComponentModel.DataAnnotations;

namespace Meetup.API.Models
{
    public class EditEventViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public Guid OrganizerId { get; set; }
        public Guid? SpeakerId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Place { get; set; }
    }
}
