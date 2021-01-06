using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IAppointmentQuestionRepository
    {
        void AddApppointmentQuestion(AppointmentQuestion appointmentQuestion);
        void RemoveAppointmentQuestion(AppointmentQuestion appointmentQuestion);
        Task<AppointmentQuestion> GetAppointmentQuestionAsync(int appointmentQuestionId);
        Task<IEnumerable<AppointmentQuestionDto>> GetAppointmentQuestionsAsync(int appointmentId);
        void Update(AppointmentQuestion appointmentQuestion);
    }
}
