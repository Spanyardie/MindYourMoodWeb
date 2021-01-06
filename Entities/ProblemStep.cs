using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class ProblemStep
    {
        public int Id { get; set; }
        public Problem Problem { get; set; }
        public string Step { get; set; }
        public int PriorityOrder { get; set; }
        public ICollection<ProblemIdea> Ideas { get; set; }
    }
}
