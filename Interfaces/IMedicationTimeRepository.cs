using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMedicationTimeRepository
    {
        void Update(MedicationTime medicationTime);
        Task<IEnumerable<MedicationTimeDto>> GetMedicationTimesAsync(int medicationSpreadId);
        Task<MedicationTime> GetMedicationTimeAsync(int medicationTimeId);
        void AddMedicationTime(MedicationTime medicationTime);
        void RemoveMedicationTime(MedicationTime medicationTime);
    }
}
