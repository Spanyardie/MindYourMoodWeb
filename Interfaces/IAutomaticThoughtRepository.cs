using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IAutomaticThoughtRepository
    {
        void Update(AutomaticThought automaticThought);
        Task<IEnumerable<AutomaticThoughtDto>> GetAutomaticThoughtsAsync(int thoughtRecordId);
        Task<AutomaticThought> GetAutomaticThoughtAsync(int automaticThoughtId);
        void AddAutomaticThought(AutomaticThought automaticThought);
        void RemoveAutomaticThought(AutomaticThought automaticThought);
    }
}
