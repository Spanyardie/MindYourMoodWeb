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
    public class GenericTextRepository : IGenericTextRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GenericTextRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 

        public void AddGenericText(GenericText genericTextItem)
        {
            _context.GenericTexts.Add(genericTextItem);
        }

        public async Task<GenericText> GetGenericTextAsync(int genericTextId)
        {
            return await _context.GenericTexts
                .Include(u => u.User)
                .SingleOrDefaultAsync(g => g.Id == genericTextId);
        }

        public async Task<IEnumerable<GenericTextDto>> GetGenericTextsAsync(int userId)
        {
            var generictexts = await _context.GenericTexts
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<GenericTextDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return generictexts;
        }

        public void RemoveGenericText(GenericText genericText)
        {
            _context.GenericTexts.Remove(genericText);
        }

        public void Update(GenericText genericText)
        {
            _context.Entry(genericText).State = EntityState.Modified;
        }
    }
}
