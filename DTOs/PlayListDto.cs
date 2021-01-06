using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class PlayListDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int TrackCount { get; set; } = 0;
    }
}
