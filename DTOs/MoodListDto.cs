using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MoodListDto
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string IsoCountry { get; set; }
        [Required]
        [StringLength(30)]
        public string MoodName { get; set; }
        public string IsDefault { get; set; } = "";
    }
}
