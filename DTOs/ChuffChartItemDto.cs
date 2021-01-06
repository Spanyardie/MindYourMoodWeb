using System;
using System.ComponentModel.DataAnnotations;

namespace MindYourMoodWeb.DTOs
{
    public class ChuffChartItemDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Achievement { get; set; }
        [Required]
        public int ChuffChartType { get; set; }
        [Required]
        public DateTime AchievementDate { get; set; }
    }
}
