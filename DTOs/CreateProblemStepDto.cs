namespace MindYourMoodWeb.DTOs
{
    public class CreateProblemStepDto
    {
        public int ProblemId { get; set; }
        public string Step { get; set; }
        public int PriorityOrder { get; set; } = 0;
    }
}
