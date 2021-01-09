using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface ISituationRepository
    {
        void Update(Situation situation);
        Task<IEnumerable<SituationDto>> GetSituationsAsync(int thoughtRecordId);
        Task<Situation> GetSituationAsync(int situationId);
        void AddSituation(Situation situation);
        void RemoveSituation(Situation situation);
    }
}
