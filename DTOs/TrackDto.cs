using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class TrackDto
    {
        public int Id { get; set; }
        [Required]
        public int PlaylistId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Artist { get; set; }
        public int OrderNumber { get; set; } = 0;
        [StringLength(300)]
        public string Uri { get; set; }
        public float Duration { get; set; } = 0.0f;
    }
}
