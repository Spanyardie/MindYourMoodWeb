using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace MindYourMoodWeb.Data
{
    public class ReRateMoodRepository : IReRateMoodRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReRateMoodRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddReRateMood(ReRateMood mood)
        {
            _context.ReRateMoods.Add(mood);
        }

        public async Task<ReRateMood> GetReRateMoodAsync(int moodId)
        {
            return await _context.ReRateMoods
                .Include(tr => tr.ThoughtRecord)
                .Include(m => m.Mood)
                .SingleOrDefaultAsync(rm => rm.Id == moodId);
        }

        public async Task<IEnumerable<ReRateMoodDto>> GetReRateMoodsAsync(int thoughtRecordId)
        {
            var rerateMoods = await _context.ReRateMoods
                .Include(tr => tr.ThoughtRecord)
                .Include(m => m.Mood)
                .Where(tr => tr.ThoughtRecord.Id == thoughtRecordId)
                .ProjectTo<ReRateMoodDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return rerateMoods;
        }

        public void RemoveReRateMood(ReRateMood mood)
        {
            _context.ReRateMoods.Remove(mood);
        }

        public void Update(ReRateMood mood)
        {
            _context.Entry(mood).State = EntityState.Modified;
        }
    }
}
