using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateSolutionReviewDto
    {
        public int IdeaId { get; set; }
        public string ReviewText { get; set; }
        public bool Achieved { get; set; } = false;
        public DateTime AchievedDate { get; set; } = DateTime.Now;
    }
}
