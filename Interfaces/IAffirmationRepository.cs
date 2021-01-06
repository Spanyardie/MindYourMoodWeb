using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IAffirmationRepository
    {
        void Update(Affirmation affirmation);
        Task<IEnumerable<AffirmationDto>> GetAffirmationsAsync(int userId);
        Task<Affirmation> GetAffirmationAsync(int affirmationId);
        void AddAffirmation(Affirmation affirmation);
        void RemoveAffirmation(Affirmation affirmation);
    }
}
