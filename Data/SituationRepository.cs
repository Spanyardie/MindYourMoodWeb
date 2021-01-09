using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Data
{
    public class SituationRepository : ISituationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SituationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddSituation(Situation situation)
        {
            _context.Situations.Add(situation);
        }

        public async Task<Situation> GetSituationAsync(int situationId)
        {
            return await _context.Situations
                .Include(tr => tr.ThoughtRecord)
                .SingleOrDefaultAsync(s => s.Id == situationId);
        }

        public async Task<IEnumerable<SituationDto>> GetSituationsAsync(int thoughtRecordId)
        {
            var situations = await _context.Situations
                .Include(tr => tr.ThoughtRecord)
                .Where(tr => tr.ThoughtRecord.Id == thoughtRecordId)
                .ProjectTo<SituationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return situations;
        }

        public void RemoveSituation(Situation situation)
        {
            _context.Situations.Remove(situation);
        }

        public void Update(Situation situation)
        {
            _context.Entry(situation).State = EntityState.Modified;
        }
    }
}
