using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class SituationDto
    {
        public int Id { get; set; }
        [Required]
        public int ThoughtRecordId { get; set; }
        [Required]
        [StringLength(200)]
        public string Who { get; set; }
        [Required]
        [StringLength(200)]
        public string What { get; set; }
        [Required]
        [StringLength(200)]
        public string When { get; set; }
        [Required]
        [StringLength(200)]
        public string Where { get; set; }
    }
}
