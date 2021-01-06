using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;

namespace MindYourMoodWeb.Data
{
    public class ChuffChartRepository : IChuffChartRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ChuffChartRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddChuffChartItem(ChuffChartItem chuffChartItem)
        {
            _context.ChuffChartitems.Add(chuffChartItem);
        }

        public async Task<ChuffChartItem> GetChuffChartItemAsync(int chuffChartItemId)
        {
            return await _context.ChuffChartitems
                .Include(u => u.User)
                .SingleOrDefaultAsync(ch => ch.Id == chuffChartItemId);
        }

        public async Task<IEnumerable<ChuffChartItemDto>> GetChuffChartItemsAsync(int userId)
        {
            var chuffChartItems = await _context.ChuffChartitems
                .Include(u => u.User)
                .Where(ch => ch.User.Id == userId)
                .ProjectTo<ChuffChartItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return chuffChartItems;
        }

        public void RemoveChuffChartItem(ChuffChartItem chuffChartItem)
        {
            _context.ChuffChartitems.Remove(chuffChartItem);
        }

        public void Update(ChuffChartItem chuffChartItem)
        {
            _context.Entry(chuffChartItem).State = EntityState.Modified;
        }
    }
}
