using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class SolutionReviewDto
    {
        public int Id { get; set; }
        [Required]
        public int IdeaId { get; set; }
        [Required]
        [StringLength(400)]
        public string ReviewText { get; set; }
        public bool Achieved { get; set; } = false;
        public DateTime AchievedDate { get; set; } = DateTime.Now;
    }
}
