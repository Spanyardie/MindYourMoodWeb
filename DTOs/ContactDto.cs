using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int Uri { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(30)]
        public string TelephoneNumber { get; set; } = "";
        [StringLength(100)]
        public string Email { get; set; } = "";
        public bool UseEmergencyCall { get; set; } = false;
        public bool UseEmergencyEmail { get; set; } = false;
        public bool UseEmergencySms { get; set; } = false;
        public string PhotoId { get; set; } = "";
    }
}
