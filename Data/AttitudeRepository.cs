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
    public class AttitudeRepository : IAttitudeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AttitudeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAttitude(Attitude attitudeItem)
        {
            _context.Attitudes.Add(attitudeItem);
        }

        public async Task<Attitude> GetAttitudeAsync(int attitudeId)
        {
            return await _context.Attitudes
                .Include(u => u.User)
                .SingleOrDefaultAsync(k => k.Id == attitudeId);
        }

        public async Task<IEnumerable<AttitudeDto>> GetAttitudesAsync(int userId)
        {
            var attitudes = await _context.Attitudes
                .Include(u => u.User)
                .Where(af => af.User.Id == userId)
                .ProjectTo<AttitudeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return attitudes;
        }

        public void RemoveAttitude(Attitude attitude)
        {
            _context.Attitudes.Remove(attitude);
        }

        public void Update(Attitude attitude)
        {
            _context.Entry(attitude).State = EntityState.Modified;
        }
    }
}
