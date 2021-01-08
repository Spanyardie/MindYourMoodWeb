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
    public class ActivityTimeRepository : IActivityTimesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ActivityTimeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddActivityTime(ActivityTimes activityTime)
        {
            _context.ActivityTimes.Add(activityTime);
        }

        public async Task<ActivityTimes> GetActivityTimeAsync(int activityTimeId)
        {
            return await _context.ActivityTimes
                .Include(a => a.Activity)
                .SingleOrDefaultAsync(at => at.Id == activityTimeId);
        }

        public async Task<IEnumerable<ActivityTimeDto>> GetActivityTimesAsync(int activityId)
        {
            var activityTimes = await _context.ActivityTimes
                .Include(a => a.Activity)
                .Where(a => a.Activity.Id == activityId)
                .ProjectTo<ActivityTimeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return activityTimes;
        }

        public void RemoveActivityTime(ActivityTimes activityTime)
        {
            _context.ActivityTimes.Remove(activityTime);
        }

        public void Update(ActivityTimes activityTime)
        {
            _context.Entry(activityTime).State = EntityState.Modified;
        }
    }
}
