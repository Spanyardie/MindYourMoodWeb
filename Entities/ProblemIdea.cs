using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class ProblemIdea : Entity
    {
        //public int Id { get; set; }
        public ProblemStep Step { get; set; }
        public Problem Problem { get; set; }
        public string IdeaText { get; set; }
        public ICollection<ProblemProCon> ProsAndCons { get; set; }
    }
}
