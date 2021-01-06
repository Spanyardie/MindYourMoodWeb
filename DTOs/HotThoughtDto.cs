using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class HotThoughtDto
    {
        public int Id { get; set; }
        [Required]
        public int AutomaticThoughtId { get; set; }
        [Required]
        [StringLength(300)]
        public string Evidence { get; set; }
        [Required]
        public int ThoughtRecordId { get; set; }
        [Required]
        public int EvidenceType { get; set; }
    }
}
