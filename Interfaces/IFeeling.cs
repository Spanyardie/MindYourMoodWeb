namespace MindYourMoodWeb.Interfaces
{
    public interface IFeeling
    {
        public enum FeelingType
        {
            Depressed,
            Anxious,
            Angry,
            Guilty,
            Ashamed,
            Sad,
            Embarrassed,
            Excited,
            Frightened,
            Irritated,
            Insecure,
            Proud,
            Mad,
            Panicky,
            Frustrated,
            Nervous,
            Disgusted,
            Hurt,
            Cheerful,
            Disappointed,
            Scared,
            Happy,
            Loving,
            Humiliated,
            Jovial,
            Melancholy,
            Flirtatious,
            Annoyed,
            Despairing,
            Lonely
        }

        public FeelingType Feeling { get; set; }
    }
}
