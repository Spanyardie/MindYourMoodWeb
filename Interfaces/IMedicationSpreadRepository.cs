using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMedicationSpreadRepository
    {
        void Update(MedicationSpread medicationSpread);
        Task<IEnumerable<MedicationSpreadDto>> GetMedicationSpreadsAsync(int medicationId);
        Task<MedicationSpread> GetMedicationSpreadAsync(int medicationSpreadId);
        void AddMedicationSpread(MedicationSpread medicationSpread);
        void RemoveMedicationSpread(MedicationSpread medicationSpread);
    }
}
