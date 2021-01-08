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
    public class MedicationRepository : IMedicationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedicationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMedication(Medication medication)
        {
            _context.Medications.Add(medication);
        }

        public async Task<Medication> GetMedicationAsync(int medicationId)
        {
            return await _context.Medications
                .Include(p => p.Prescription)
                .Include(ms => ms.MedicationSpreads)
                .SingleOrDefaultAsync(m => m.Id == medicationId);
        }

        public async Task<IEnumerable<MedicationDto>> GetMedicationsAsync(int prescriptionId)
        {
            var medications = await _context.Medications
                .Include(p => p.Prescription)
                .Include(ms => ms.MedicationSpreads)
                .Where(p => p.Prescription.Id == prescriptionId)
                .ProjectTo<MedicationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return medications;
        }

        public void RemoveMedication(Medication medication)
        {
            _context.Medications.Remove(medication);
        }

        public void Update(Medication medication)
        {
            _context.Entry(medication).State = EntityState.Modified;
        }
    }
}
