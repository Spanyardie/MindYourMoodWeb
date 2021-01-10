using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class SolutionPlanDto
    {
        public int Id { get; set; }
        [Required]
        public int IdeaId { get; set; }
        [Required]
        [StringLength(400)]
        public string SolutionStep { get; set; }
        public int PriorityOrder { get; set; } = 0;
        public int SolutionReviewId { get; set; }
    }
}
