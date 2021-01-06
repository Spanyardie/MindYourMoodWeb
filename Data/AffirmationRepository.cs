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
    public class AffirmationRepository : IAffirmationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AffirmationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAffirmation(Affirmation affirmation)
        {
            _context.Affirmations.Add(affirmation);
        }

        public async Task<Affirmation> GetAffirmationAsync(int affirmationId)
        {
            return await _context.Affirmations
                .Include(u => u.User)
                .Where(af => af.Id == affirmationId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AffirmationDto>> GetAffirmationsAsync(int userId)
        {
            var affirmations = await _context.Affirmations
                .Include(u => u.User)
                .Where(af => af.User.Id == userId)
                .ProjectTo<AffirmationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return affirmations;
        }

        public void RemoveAffirmation(Affirmation affirmation)
        {
            _context.Affirmations.Remove(affirmation);
        }

        public void Update(Affirmation affirmation)
        {
            _context.Entry(affirmation).State = EntityState.Modified;
        }
    }
}
