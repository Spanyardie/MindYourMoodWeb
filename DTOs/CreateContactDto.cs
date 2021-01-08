namespace MindYourMoodWeb.DTOs
{
    public class CreateContactDto
    {
        public int Uri { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public bool UseEmergencyCall { get; set; } = false;
        public bool UseEmergencyEmail { get; set; } = false;
        public bool UseEmergencySms { get; set; } = false;
        public string PhotoId { get; set; } = "";
        public int UserId { get; set; }
    }
}
