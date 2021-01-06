using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace MindYourMoodWeb.Data
{
    public class AppointmentQuestionRepository : IAppointmentQuestionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AppointmentQuestionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddApppointmentQuestion(AppointmentQuestion appointmentQuestion)
        {
            _context.AppointmentQuestions.Add(appointmentQuestion);
        }

        public async Task<AppointmentQuestion> GetAppointmentQuestionAsync(int appointmentQuestionId)
        {
            return await _context.AppointmentQuestions
                .Include(a => a.Appointment)
                .SingleOrDefaultAsync(aq => aq.Id == appointmentQuestionId);
        }

        public async Task<IEnumerable<AppointmentQuestionDto>> GetAppointmentQuestionsAsync(int appointmentId)
        {
            var questions = await _context.AppointmentQuestions
                .Include(aq => aq.Appointment)
                .Where(a => a.Appointment.Id == appointmentId)
                .ProjectTo<AppointmentQuestionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return questions;
        }

        public void RemoveAppointmentQuestion(AppointmentQuestion appointmentQuestion)
        {
            _context.AppointmentQuestions.Remove(appointmentQuestion);
        }

        public void Update(AppointmentQuestion appointmentQuestion)
        {
            _context.Entry(appointmentQuestion).State = EntityState.Modified;
        }
    }
}
