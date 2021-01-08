using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IMedicationRepository
    {
        void Update(Medication medication);
        Task<IEnumerable<MedicationDto>> GetMedicationsAsync(int userId);
        Task<Medication> GetMedicationAsync(int medicationId);
        void AddMedication(Medication medication);
        void RemoveMedication(Medication medication);
    }
}
