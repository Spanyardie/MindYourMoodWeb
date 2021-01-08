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
    public class MoodListRepository : IMoodListRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoodListRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMoodList(MoodList moodList)
        {
            _context.MoodLists.Add(moodList);
        }

        public async Task<MoodList> GetMoodListAsync(int moodListId)
        {
            return await _context.MoodLists.SingleOrDefaultAsync(ml => ml.Id == moodListId);
        }

        public async Task<IEnumerable<MoodListDto>> GetMoodListsAsync()
        {
            return await _context.MoodLists
                .ProjectTo<MoodListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public void RemoveMoodList(MoodList moodList)
        {
            _context.MoodLists.Remove(moodList);
        }

        public void Update(MoodList moodList)
        {
            _context.Entry(moodList).State = EntityState.Modified;
        }
    }
}
