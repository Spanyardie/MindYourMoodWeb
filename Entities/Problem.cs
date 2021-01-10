using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Problem : Entity
    {
        public string ProblemText { get; set; }
        public ICollection<ProblemStep> Steps { get; set; }
        public AppUser User { get; set; }
    }
}
