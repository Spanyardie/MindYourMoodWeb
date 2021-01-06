namespace MindYourMoodWeb.Entities
{
    public class SolutionPlan
    {
        public int Id { get; set; }
        public SolutionReview SolutionReview { get; set; }
        public string SolutionStep { get; set; }
        public int PriorityOrder { get; set; }
    }
}
