using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IFeelingRepository
    {
        void Update(Feeling feeling);
        Task<IEnumerable<FeelingDto>> GetFeelingsAsync(int userId);
        Task<Feeling> GetFeelingAsync(int feelingId);
        void AddFeeling(Feeling feelingItem);
        void RemoveFeeling(Feeling feeling);
    }
}
