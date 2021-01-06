using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IChuffChartRepository
    {
        void Update(ChuffChartItem chuffChartItem);
        Task<IEnumerable<ChuffChartItemDto>> GetChuffChartItemsAsync(int userId);
        Task<ChuffChartItem> GetChuffChartItemAsync(int chuffChartItemId);
        void AddChuffChartItem(ChuffChartItem chuffChartItem);
        void RemoveChuffChartItem(ChuffChartItem chuffChartItem);
    }
}
