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
    public class EvidenceForHotThoughtRepository : IEvidenceForHotThoughtRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EvidenceForHotThoughtRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddEvidenceForHotThought(EvidenceForHotThought evidenceForHotThought)
        {
            _context.EvidencesForHotThought.Add(evidenceForHotThought);
        }

        public async Task<EvidenceForHotThought> GetEvidenceForHotThoughtAsync(int evidenceForHotThoughtId)
        {
            return await _context.EvidencesForHotThought
                .Include(at => at.AutomaticThought)
                .SingleOrDefaultAsync(ef => ef.Id == evidenceForHotThoughtId);
        }

        public async Task<IEnumerable<EvidenceForHotThoughtDto>> GetEvidencesForHotThoughtAsync(int automaticThoughtId)
        {
            var evidencesFor = await _context.EvidencesForHotThought
                .Include(at => at.AutomaticThought)
                .Where(at => at.AutomaticThought.Id == automaticThoughtId)
                .ProjectTo<EvidenceForHotThoughtDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return evidencesFor;
        }

        public void RemoveEvidenceForHotThought(EvidenceForHotThought evidenceForHotThought)
        {
            _context.EvidencesForHotThought.Remove(evidenceForHotThought);
        }

        public void Update(EvidenceForHotThought evidenceForHotThought)
        {
            _context.Entry(evidenceForHotThought).State = EntityState.Modified;
        }
    }
}
