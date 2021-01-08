using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IReRateMoodRepository
    {
        void Update(ReRateMood mood);
        Task<IEnumerable<ReRateMoodDto>> GetReRateMoodsAsync(int thoughtRecordId);
        Task<ReRateMood> GetReRateMoodAsync(int moodId);
        void AddReRateMood(ReRateMood mood);
        void RemoveReRateMood(ReRateMood mood);
    }
}
