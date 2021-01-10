namespace MindYourMoodWeb.DTOs
{
    public class CreateProblemProConDto
    {
        public int IdeaId { get; set; }
        public int StepId { get; set; }
        public int ProblemId { get; set; }
        public string ProConText { get; set; }
        public int Type { get; set; } = 0;
    }
}
