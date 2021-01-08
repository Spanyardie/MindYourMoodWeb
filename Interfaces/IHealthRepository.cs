using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MindYourMoodWeb.Interfaces
{
    public interface IHealthRepository
    {
        void Update(Health health);
        Task<IEnumerable<HealthDto>> GetHealthsAsync(int userId);
        Task<Health> GetHealthAsync(int healthId);
        void AddHealth(Health healthItem);
        void RemoveHealth(Health health);
    }
}
