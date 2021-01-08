using System.Threading.Tasks;
using AutoMapper;
using MindYourMoodWeb.Interfaces;

namespace MindYourMoodWeb.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IAffirmationRepository AffirmationRepository => new AffirmationRepository(_context, _mapper);
        public IChuffChartRepository ChuffChartRepository => new ChuffChartRepository(_context, _mapper);
        public IAppointmentRepository AppointmentRepository => new AppointmentRepository(_context, _mapper);
        public IAppointmentQuestionRepository AppointmentQuestionRepository => new AppointmentQuestionRepository(_context, _mapper);
        public IAttitudeRepository AttitudeRepository => new AttitudeRepository(_context, _mapper);
        public IFantasyRepository FantasyRepository => new FantasyRepository(_context, _mapper);
        public IFeelingRepository FeelingRepository => new FeelingRepository(_context, _mapper);
        public IGenericTextRepository GenericTextRepository => new GenericTextRepository(_context, _mapper);
        public IHealthRepository HealthRepository => new HealthRepository(_context, _mapper);
        public IPrescriptionRepository PrescriptionRepository => new PrescriptionRepository(_context, _mapper);
        public IMedicationRepository MedicationRepository => new MedicationRepository(_context, _mapper);
        public IMedicationSpreadRepository MedicationSpreadRepository => new MedicationSpreadRepository(_context, _mapper);
        public IMedicationReminderRepository MedicationReminderRepository => new MedicationReminderRepository(_context, _mapper);
        public IMedicationTimeRepository MedicationTimeRepository => new MedicationTimeRepository(_context, _mapper);
        public IMoodRepository MoodRepository => new MoodRepository(_context, _mapper);
        public IMoodListRepository MoodListRepository => new MoodListRepository(_context, _mapper);
        public IPlayListRepository PlayListRepository => new PlayListRepository(_context, _mapper);

        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
