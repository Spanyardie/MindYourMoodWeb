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
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ActivitiesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddActivity(Activities activities)
        {
            _context.Activities.Add(activities);
        }

        public async Task<IEnumerable<ActivityDto>> GetActivitiesAsync(int userId)
        {
            var activities = await _context.Activities
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return activities;
        }

        public async Task<Activities> GetActivityAsync(int activityId)
        {
            return await _context.Activities
                .Include(u => u.User)
                .SingleOrDefaultAsync(a => a.Id == activityId);
        }

        public void RemoveActivity(Activities activities)
        {
            _context.Activities.Remove(activities);
        }

        public void Update(Activities activities)
        {
            _context.Entry(activities).State = EntityState.Modified;
        }
    }
}
