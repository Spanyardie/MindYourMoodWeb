using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMedicationReminderRepository
    {
        void Update(MedicationReminder medicationReminder);
        Task<IEnumerable<MedicationReminderDto>> GetMedicationRemindersAsync(int medicationSpreadId);
        Task<MedicationReminder> GetMedicationReminderAsync(int medicationReminderId);
        void AddMedicationReminder(MedicationReminder medicationReminder);
        void RemoveMedicationReminder(MedicationReminder medicationReminder);
    }
}
