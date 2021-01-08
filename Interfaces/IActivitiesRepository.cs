using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IActivitiesRepository
    {
        void Update(Activities activities);
        Task<IEnumerable<ActivityDto>> GetActivitiesAsync(int userId);
        Task<Activities> GetActivityAsync(int activityId);
        void AddActivity(Activities activities);
        void RemoveActivity(Activities activities);
    }
}
