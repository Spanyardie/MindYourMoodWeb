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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PrescriptionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
        }

        public async Task<Prescription> GetPrescriptionAsync(int prescriptionId)
        {
            return await _context.Prescriptions
                .Include(u => u.User)
                .Include(m => m.Medications)
                .SingleOrDefaultAsync(u => u.Id == prescriptionId);
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync(int userId)
        {
            var prescriptions = await _context.Prescriptions
                .Include(u => u.User)
                .Include(m => m.Medications)
                .Where(u => u.User.Id == userId)
                .ProjectTo<PrescriptionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return prescriptions;
        }

        public void RemovePrescription(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
        }

        public void Update(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
        }
    }
}
