namespace MindYourMoodWeb.Entities
{
    public class SolutionPlan : Entity
    {
        public SolutionReview SolutionReview { get; set; }
        public string SolutionStep { get; set; }
        public int PriorityOrder { get; set; }
    }
}
