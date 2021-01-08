using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMoodRepository
    {
        void Update(Mood mood);
        Task<IEnumerable<MoodDto>> GetMoodsAsync(int thoughtRecordId);
        Task<Mood> GetMoodAsync(int moodId);
        void AddMood(Mood mood);
        void RemoveMood(Mood mood);
    }
}
