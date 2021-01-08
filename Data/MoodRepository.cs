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
    public class MoodRepository : IMoodRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoodRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMood(Mood mood)
        {
            _context.Moods.Add(mood);
        }

        public async Task<Mood> GetMoodAsync(int moodId)
        {
            return await _context.Moods
                .Include(ml => ml.MoodList)
                .Include(tr => tr.ThoughtRecord)
                .SingleOrDefaultAsync(m => m.Id == moodId);
        }

        public async Task<IEnumerable<MoodDto>> GetMoodsAsync(int thoughtRecordId)
        {
            var moods = await _context.Moods
                .Include(ml => ml.MoodList)
                .Include(tr => tr.ThoughtRecord)
                .Where(tr => tr.ThoughtRecord.Id == thoughtRecordId)
                .ProjectTo<MoodDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return moods;
        }

        public void RemoveMood(Mood mood)
        {
            _context.Moods.Remove(mood);
        }

        public void Update(Mood mood)
        {
            _context.Entry(mood).State = EntityState.Modified;
        }
    }
}
