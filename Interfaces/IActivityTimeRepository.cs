using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IActivityTimesRepository
    {
        void Update(ActivityTimes activityTime);
        Task<IEnumerable<ActivityTimeDto>> GetActivityTimesAsync(int activityId);
        Task<ActivityTimes> GetActivityTimeAsync(int activityTimeId);
        void AddActivityTime(ActivityTimes activityTime);
        void RemoveActivityTime(ActivityTimes activityTime);
    }
}
