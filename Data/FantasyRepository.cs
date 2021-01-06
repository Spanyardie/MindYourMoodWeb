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
    public class FantasyRepository : IFantasyRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FantasyRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddFantasy(Fantasy fantasyItem)
        {
            _context.Fantasies.Add(fantasyItem);
        }

        public async Task<IEnumerable<FantasyDto>> GetFantasiesAsync(int userId)
        {
            var fantasies = await _context.Fantasies
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<FantasyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return fantasies;
        }

        public async Task<Fantasy> GetFantasyAsync(int fantasyId)
        {
            return await _context.Fantasies
                .Include(u => u.User)
                .SingleOrDefaultAsync(f => f.Id == fantasyId);
        }

        public void RemoveFantasy(Fantasy fantasy)
        {
            _context.Fantasies.Remove(fantasy);
        }

        public void Update(Fantasy fantasy)
        {
            _context.Entry(fantasy).State = EntityState.Modified;
        }
    }
}
