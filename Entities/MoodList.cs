namespace MindYourMoodWeb.Entities
{
    public class MoodList : Entity
    {
        //public int Id { get; set; }
        public string IsoCountry { get; set; }
        public string MoodName { get; set; }
        public string IsDefault { get; set; }
    }
}
