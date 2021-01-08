using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IEvidenceAgainstHotThoughtRepository
    {
        void Update(EvidenceAgainstHotThought evidenceAgainstHotThought);
        Task<IEnumerable<EvidenceAgainstHotThoughtDto>> GetEvidenceAgainstHotThoughtsAsync(int automaticThoughtId);
        Task<EvidenceAgainstHotThought> GetEvidenceAgainstHotThoughtAsync(int evidenceAgainstHotThoughtId);
        void AddEvidenceAgainstHotThought(EvidenceAgainstHotThought evidenceAgainstHotThought);
        void RemoveEvidenceAgainstHotThought(EvidenceAgainstHotThought evidenceAgainstHotThought);
    }
}
