namespace MindYourMoodWeb.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public int Uri { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public bool UseEmergencyCall { get; set; }
        public bool UseEmergencyEmail { get; set; }
        public bool UseEmergencySms { get; set; }
        public string PhotoId { get; set; }
        public AppUser User { get; set; }
    }
}
