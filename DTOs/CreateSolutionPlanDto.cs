namespace MindYourMoodWeb.DTOs
{
    public class CreateSolutionPlanDto
    {
        public int IdeaId { get; set; }
        public string SolutionStep { get; set; }
        public int PriorityOrder { get; set; } = 0;
        public int SolutionReviewId { get; set; }
    }
}
