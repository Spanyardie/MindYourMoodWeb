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
    public class MedicationReminderRepository : IMedicationReminderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MedicationReminderRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMedicationReminder(MedicationReminder medicationReminder)
        {
            _context.MedicationReminders.Add(medicationReminder);
        }

        public async Task<MedicationReminder> GetMedicationReminderAsync(int medicationReminderId)
        {
            return await _context.MedicationReminders
                .Include(ms => ms.MedicationSpread)
                .SingleOrDefaultAsync(mr => mr.Id == medicationReminderId);
        }

        public async Task<IEnumerable<MedicationReminderDto>> GetMedicationRemindersAsync(int medicationSpreadId)
        {
            var reminders = await _context.MedicationReminders
                .Include(ms => ms.MedicationSpread)
                .Where(ms => ms.MedicationSpread.Id == medicationSpreadId)
                .ProjectTo<MedicationReminderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return reminders;
        }

        public void RemoveMedicationReminder(MedicationReminder medicationReminder)
        {
            _context.MedicationReminders.Remove(medicationReminder);
        }

        public void Update(MedicationReminder medicationReminder)
        {
            _context.Entry(medicationReminder).State = EntityState.Modified;
        }
    }
}
