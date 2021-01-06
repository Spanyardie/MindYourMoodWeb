using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class TellMyselfDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string TellText { get; set; }
        [Required]
        [StringLength(200)]
        public string TellTitle { get; set; }
    }
}
