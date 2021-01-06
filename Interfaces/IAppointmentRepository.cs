using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IAppointmentRepository
    {
        void Update(Appointment appointment);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int userId);
        Task<Appointment> GetAppointmentAsync(int appointmentId);
        void AddAppointmentItem(Appointment appointment);
        void RemoveAppointment(Appointment appointment);
    }
}
