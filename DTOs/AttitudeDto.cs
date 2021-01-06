using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AttitudeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ToWhat { get; set; }
        public int Strength { get; set; } = 0;
        [Required]
        public int Type { get; set; }
        [Required]
        public int Feeling { get; set; }
        [Required]
        public int DoAction { get; set; }
        public string ActionOf { get; set; } = "";
        public int UserId { get; set; }
    }
}
