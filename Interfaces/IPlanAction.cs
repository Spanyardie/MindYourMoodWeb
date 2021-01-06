namespace MindYourMoodWeb.Interfaces
{
    public interface IPlanAction
    {
        public enum ReactionType
        {
            Positive,
            Negative,
            Ambivalent
        }

        public enum ActionType
        {
            DoMore,
            DoLess,
            Maintain
        }
    }
}
