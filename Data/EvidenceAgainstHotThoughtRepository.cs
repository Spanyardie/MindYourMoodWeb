using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MindYourMoodWeb.Data
{
    public class EvidenceAgainstHotThoughtRepository : IEvidenceAgainstHotThoughtRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EvidenceAgainstHotThoughtRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddEvidenceAgainstHotThought(EvidenceAgainstHotThought evidenceAgainstHotThought)
        {
            _context.EvidencesAgainstHotThought.Add(evidenceAgainstHotThought);
        }

        public async Task<EvidenceAgainstHotThought> GetEvidenceAgainstHotThoughtAsync(int evidenceAgainstHotThoughtId)
        {
            return await _context.EvidencesAgainstHotThought
                .Include(at => at.AutomaticThought)
                .Include(tr => tr.ThoughtRecord)
                .SingleOrDefaultAsync(ea => ea.Id == evidenceAgainstHotThoughtId);
        }

        public async Task<IEnumerable<EvidenceAgainstHotThoughtDto>> GetEvidenceAgainstHotThoughtsAsync(int automaticThoughtId)
        {
            var evidencesAgainst = await _context.EvidencesAgainstHotThought
                .Include(at => at.AutomaticThought)
                .Include(tr => tr.ThoughtRecord)
                .Where(at => at.AutomaticThought.Id == automaticThoughtId)
                .ProjectTo<EvidenceAgainstHotThoughtDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return evidencesAgainst;
        }

        public void RemoveEvidenceAgainstHotThought(EvidenceAgainstHotThought evidenceAgainstHotThought)
        {
            _context.EvidencesAgainstHotThought.Remove(evidenceAgainstHotThought);
        }

        public void Update(EvidenceAgainstHotThought evidenceAgainstHotThought)
        {
            _context.Entry(evidenceAgainstHotThought).State = EntityState.Modified;
        }
    }
}
