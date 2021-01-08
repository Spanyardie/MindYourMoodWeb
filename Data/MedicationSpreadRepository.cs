using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Data
{
    public class MedicationSpreadRepository : IMedicationSpreadRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedicationSpreadRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMedicationSpread(MedicationSpread medicationSpread)
        {
            _context.MedicationsSpreads.Add(medicationSpread);
        }

        public async Task<MedicationSpread> GetMedicationSpreadAsync(int medicationId)
        {
            return await _context.MedicationsSpreads
                .Include(m => m.Medication)
                .SingleOrDefaultAsync(m => m.Medication.Id == medicationId);
        }

        public async Task<IEnumerable<MedicationSpreadDto>> GetMedicationSpreadsAsync(int medicationId)
        {
            var medicationSpreads = await _context.MedicationsSpreads
                .Include(m => m.Medication)
                .Where(m => m.Medication.Id == medicationId)
                .ProjectTo<MedicationSpreadDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return medicationSpreads;
        }

        public void RemoveMedicationSpread(MedicationSpread medicationSpread)
        {
            _context.MedicationsSpreads.Remove(medicationSpread);
        }

        public void Update(MedicationSpread medicationSpread)
        {
            _context.Entry(medicationSpread).State = EntityState.Modified;
        }
    }
}
