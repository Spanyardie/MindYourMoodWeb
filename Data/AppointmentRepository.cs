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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AppointmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAppointmentItem(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

        public async Task<Appointment> GetAppointmentAsync(int appointmentId)
        {
            return await _context.Appointments
                .Include(u => u.User)
                .SingleOrDefaultAsync(ap => ap.Id == appointmentId);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int userId)
        {
            var appointments = await _context.Appointments
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return appointments;
        }

        public void RemoveAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
        }
    }
}
