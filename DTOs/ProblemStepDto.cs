using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ProblemStepDto
    {
        public int Id { get; set; }
        [Required]
        public int ProblemId { get; set; }
        [Required]
        [StringLength(400)]
        public string Step { get; set; }
        [Required]
        public int PriorityOrder { get; set; } = 0;
    }
}
