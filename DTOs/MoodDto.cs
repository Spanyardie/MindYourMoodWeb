using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class MoodDto
    {
        public int Id { get; set; }
        [Required]
        public int MoodListId { get; set; }
        public int MoodRating { get; set; } = 0;
        [Required]
        public int ThoughtRecordId { get; set; }
    }
}
