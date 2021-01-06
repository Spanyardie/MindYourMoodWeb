using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class AlternativeThoughtDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Alternative { get; set; }
        public int BeliefRating { get; set; } = 0;
        [Required]
        public int ThoughtRecordId { get; set; }
    }
}
