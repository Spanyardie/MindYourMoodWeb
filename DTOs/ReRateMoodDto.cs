using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ReRateMoodDto
    {
        public int Id { get; set; }
        [Required]
        public int MoodListId { get; set; }
        public int MoodRating { get; set; } = 0;
        [Required]
        public int MoodsId { get; set; }
        [Required]
        public int ThoughtRecordId { get; set; }
    }
}
