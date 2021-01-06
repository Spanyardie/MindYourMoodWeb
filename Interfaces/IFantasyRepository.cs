using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IFantasyRepository
    {
        void Update(Fantasy fantasy);
        Task<IEnumerable<FantasyDto>> GetFantasiesAsync(int userId);
        Task<Fantasy> GetFantasyAsync(int fantasyId);
        void AddFantasy(Fantasy fantasyItem);
        void RemoveFantasy(Fantasy fantasy);
    }
}
