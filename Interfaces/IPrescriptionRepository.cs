using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IPrescriptionRepository
    {
        void Update(Prescription prescription);
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync(int userId);
        Task<Prescription> GetPrescriptionAsync(int prescriptionId);
        void AddPrescription(Prescription prescription);
        void RemovePrescription(Prescription prescription);
    }
}
