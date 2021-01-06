using System;

namespace MindYourMoodWeb.DTOs
{
    public class CreateChuffChartItemDto
    {
        public string Achievement { get; set; }
        public int ChuffChartType { get; set; }
        public DateTime AchievementDate { get; set; }
    }
}
