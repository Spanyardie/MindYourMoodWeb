using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string Uri { get; set; }
        [StringLength(300)]
        public string Comment { get; set; } = "";
        public int UserId { get; set; }
    }
}
