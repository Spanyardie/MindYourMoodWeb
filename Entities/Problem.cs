using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Problem
    {
        public int Id { get; set; }
        public string ProblemText { get; set; }
        public ICollection<ProblemStep> Steps { get; set; }
        public AppUser User { get; set; }
    }
}
