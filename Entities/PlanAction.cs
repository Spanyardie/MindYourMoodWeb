using MindYourMoodWeb.Interfaces;
using static MindYourMoodWeb.Interfaces.IPlanAction;

namespace MindYourMoodWeb.Entities
{
    public class PlanAction : Entity, IPlanAction
    {
        //public int Id { get; set; }
        public string ToWhat { get; set; }
        public int Strength { get; set; }
        public ReactionType Type { get; set; }
        public ActionType DoAction { get; set; }
        public string ActionOf { get; set; }
        public AppUser User { get; set; }
    }
}
