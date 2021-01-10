namespace MindYourMoodWeb.Entities
{
    public class AlternativeThought : Entity
    {
        //public int Id { get; set; }
        public string Alternative { get; set; }
        public int BeliefRating { get; set; }
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
