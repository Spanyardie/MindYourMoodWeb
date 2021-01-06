using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AffirmationDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(300)]
        public string AffirmationText { get; set; }
    }
}
