using System;

namespace MindYourMoodWeb.Entities
{
    public class ChuffChartItem
    {
        public enum AchievementType
        {
            General,
            Life,
            Work,
            Family,
            Relationships,
            Health,
            Financial,
            Affirmation,
            Goal
        }

        public int Id { get; set; }
        public string Achievement { get; set; }
        public AchievementType ChuffChartType { get; set; }
        public DateTime AchievementDate { get; set; }
        public AppUser User { get; set; }
    }
}
