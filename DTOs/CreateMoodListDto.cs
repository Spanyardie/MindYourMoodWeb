namespace MindYourMoodWeb.DTOs
{
    public class CreateMoodListDto
    {
        public string IsoCountry { get; set; }
        public string MoodName { get; set; }
        public string IsDefault { get; set; } = "";
    }
}
