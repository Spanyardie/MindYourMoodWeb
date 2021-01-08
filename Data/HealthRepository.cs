using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindYourMoodWeb.Interfaces;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace MindYourMoodWeb.Data
{
    public class HealthRepository : IHealthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HealthRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddHealth(Health healthItem)
        {
            _context.Healths.Add(healthItem);
        }

        public async Task<Health> GetHealthAsync(int healthId)
        {
            return await _context.Healths
                .Include(u => u.User)
                .SingleOrDefaultAsync(h => h.Id == healthId);
        }

        public async Task<IEnumerable<HealthDto>> GetHealthsAsync(int userId)
        {
            var healths = await _context.Healths
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<HealthDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return healths;
        }

        public void RemoveHealth(Health health)
        {
            _context.Healths.Remove(health);
        }

        public void Update(Health health)
        {
            _context.Entry(health).State = EntityState.Modified;
        }
    }
}
