using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ActivityTimeDto
    {
        public int Id { get; set; }
        [Required]
        public int ActivityId { get; set; }
        [Required]
        [StringLength(50)]
        public string ActivityName { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int Achievement { get; set; } = 0;
        public int Intimacy { get; set; } = 0;
        public int Pleasure { get; set; } = 0;
    }
}
