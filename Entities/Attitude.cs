using MindYourMoodWeb.Interfaces;

namespace MindYourMoodWeb.Entities
{
    public class Attitude : PlanAction, IFeeling
    {
        private IFeeling.FeelingType _feeling;

        public IFeeling.FeelingType Feeling 
        { 
            get => _feeling; 
            set => _feeling = value; 
        }
    }
}
