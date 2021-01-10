namespace MindYourMoodWeb.Entities
{
    public class ProblemProCon : Entity
    {
        public enum ProblemType
        {
            Pro,
            Con
        }

        //public int Id { get; set; }
        public ProblemIdea Idea { get; set; }
        public ProblemStep Step { get; set; }
        public Problem Problem { get; set; }
        public string ProConText { get; set; }
        public ProblemType Type { get; set; }
    }
}
