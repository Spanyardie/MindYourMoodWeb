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
    public class FeelingRepository : IFeelingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FeelingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddFeeling(Feeling feelingItem)
        {
            _context.Feelings.Add(feelingItem);
        }

        public async Task<Feeling> GetFeelingAsync(int feelingId)
        {
            return await _context.Feelings
                .Include(u => u.User)
                .SingleOrDefaultAsync(f => f.Id == feelingId);
        }

        public async Task<IEnumerable<FeelingDto>> GetFeelingsAsync(int userId)
        {
            var feelings = await _context.Feelings
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<FeelingDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return feelings;
        }

        public void RemoveFeeling(Feeling feeling)
        {
            _context.Feelings.Remove(feeling);
        }

        public void Update(Feeling feeling)
        {
            _context.Entry(feeling).State = EntityState.Modified;
        }
    }
}
