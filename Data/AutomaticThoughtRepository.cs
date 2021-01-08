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
    public class AutomaticThoughtRepository : IAutomaticThoughtRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AutomaticThoughtRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAutomaticThought(AutomaticThought automaticThought)
        {
            _context.AutomaticThoughts.Add(automaticThought);
        }

        public async Task<AutomaticThought> GetAutomaticThoughtAsync(int automaticThoughtId)
        {
            return await _context.AutomaticThoughts
                .Include(tr => tr.ThoughtRecord)
                .SingleOrDefaultAsync(at => at.Id == automaticThoughtId);
        }

        public async Task<IEnumerable<AutomaticThoughtDto>> GetAutomaticThoughtsAsync(int thoughtRecordId)
        {
            var automaticThoughts = await _context.AutomaticThoughts
                .Include(tr => tr.ThoughtRecord)
                .Where(tr => tr.ThoughtRecord.Id == thoughtRecordId)
                .ProjectTo<AutomaticThoughtDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return automaticThoughts;
        }

        public void RemoveAutomaticThought(AutomaticThought automaticThought)
        {
            _context.AutomaticThoughts.Remove(automaticThought);
        }

        public void Update(AutomaticThought automaticThought)
        {
            _context.Entry(automaticThought).State = EntityState.Modified;
        }
    }
}
