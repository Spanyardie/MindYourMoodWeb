using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AppointmentQuestionDto
    {
        public int Id { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string Question { get; set; }
        public string Answer { get; set; } = "";
    }
}
