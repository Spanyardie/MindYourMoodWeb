using System;
using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class SolutionReview : Entity
    {
        //public int Id { get; set; }
        public ProblemIdea Idea { get; set; }
        public ICollection<SolutionPlan> SolutionSteps { get; set; }
        public string ReviewText { get; set; }
        public bool Achieved { get; set; }
        public DateTime AchievedDate { get; set; }
    }
}
