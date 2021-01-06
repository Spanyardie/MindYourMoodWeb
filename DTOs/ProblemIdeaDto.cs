using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ProblemIdeaDto
    {
        public int Id { get; set; }
        [Required]
        public int StepId { get; set; }
        [Required]
        public int ProblemId { get; set; }
        [Required]
        [StringLength(400)]
        public string IdeaText { get; set; }
    }
}
