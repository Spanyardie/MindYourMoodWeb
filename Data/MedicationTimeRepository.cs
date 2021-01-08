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
    public class MedicationTimeRepository : IMedicationTimeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedicationTimeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMedicationTime(MedicationTime medicationTime)
        {
            _context.MedicationTimes.Add(medicationTime);
        }

        public async Task<MedicationTime> GetMedicationTimeAsync(int medicationTimeId)
        {
            return await _context.MedicationTimes
                .Include(ms => ms.Spread)
                .SingleOrDefaultAsync(mt => mt.Id == medicationTimeId);
        }

        public async Task<IEnumerable<MedicationTimeDto>> GetMedicationTimesAsync(int medicationSpreadId)
        {
            var medicationTimes = await _context.MedicationTimes
                .Include(ms => ms.Spread)
                .Where(ms => ms.Spread.Id == medicationSpreadId)
                .ProjectTo<MedicationTimeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return medicationTimes;
        }

        public void RemoveMedicationTime(MedicationTime medicationTime)
        {
            _context.MedicationTimes.Remove(medicationTime);
        }

        public void Update(MedicationTime medicationTime)
        {
            _context.Entry(medicationTime).State = EntityState.Modified;
        }
    }
}
