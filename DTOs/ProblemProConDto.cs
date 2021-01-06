using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ProblemProConDto
    {
        public int Id { get; set; }
        [Required]
        public int IdeaId { get; set; }
        [Required]
        public int StepId { get; set; }
        [Required]
        public int ProblemId { get; set; }
        [Required]
        [StringLength(400)]
        public string ProConText { get; set; }
        [Required]
        public int Type { get; set; } = 0;
    }
}
