using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMoodListRepository
    {
        void Update(MoodList moodList);
        Task<IEnumerable<MoodListDto>> GetMoodListsAsync();
        Task<MoodList> GetMoodListAsync(int moodListId);
        void AddMoodList(MoodList moodList);
        void RemoveMoodList(MoodList moodList);
    }
}
