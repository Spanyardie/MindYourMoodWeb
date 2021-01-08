using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IEvidenceForHotThoughtRepository
    {
        void Update(EvidenceForHotThought evidenceForHotThought);
        Task<IEnumerable<EvidenceForHotThoughtDto>> GetEvidencesForHotThoughtAsync(int automaticThoughtId);
        Task<EvidenceForHotThought> GetEvidenceForHotThoughtAsync(int evidenceForHotThoughtId);
        void AddEvidenceForHotThought(EvidenceForHotThought evidenceForHotThought);
        void RemoveEvidenceForHotThought(EvidenceForHotThought evidenceForHotThought);
    }
}
