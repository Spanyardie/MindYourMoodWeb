using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
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

        //public IAffirmationRepository AffirmationRepository => new AffirmationRepository(_context, _mapper);
        public IRepository<Affirmation, AffirmationDto> AffirmationRepository => new AffirmationRepository(_context, _mapper, new[] { "User" });
        //public IChuffChartRepository ChuffChartRepository => new ChuffChartRepository(_context, _mapper);
        public IRepository<ChuffChartItem, ChuffChartItemDto> ChuffChartRepository => new ChuffChartRepository(_context, _mapper, new[] { "User" });
        //public IAppointmentRepository AppointmentsRepository => new AppointmentRepository(_context, _mapper);
        public IRepository<Appointment, AppointmentDto> AppointmentsRepository => new AppointmentRepository(_context, _mapper, new[] { "User" });
        //public IAppointmentQuestionRepository AppointmentQuestionsRepository => new AppointmentQuestionRepository(_context, _mapper);
        public IRepository<AppointmentQuestion, AppointmentQuestionDto> AppointmentQuestionsRepository => new AppointmentQuestionRepository(_context, _mapper, new[] { "Appointment" });
        //public IAttitudeRepository AttitudeRepository => new AttitudeRepository(_context, _mapper);
        public IRepository<Attitude, AttitudeDto> AttitudeRepository => new AttitudeRepository(_context, _mapper, new[] { "User" });
        //public IFantasyRepository FantasyRepository => new FantasyRepository(_context, _mapper);
        public IRepository<Fantasy, FantasyDto> FantasyRepository => new FantasyRepository(_context, _mapper, new[] { "User" });
        //public IFeelingRepository FeelingRepository => new FeelingRepository(_context, _mapper);
        public IRepository<Feeling, FeelingDto> FeelingRepository => new FeelingRepository(_context, _mapper, new[] { "User" });
        //public IGenericTextRepository GenericTextRepository => new GenericTextRepository(_context, _mapper);
        public IRepository<GenericText, GenericTextDto> GenericTextRepository => new GenericTextRepository(_context, _mapper, new[] { "User" });
        //public IHealthRepository HealthRepository => new HealthRepository(_context, _mapper);
        public IRepository<Health, HealthDto> HealthRepository => new HealthRepository(_context, _mapper, new[] { "user" });
        //public IPrescriptionRepository PrescriptionRepository => new PrescriptionRepository(_context, _mapper);
        public IRepository<Prescription, PrescriptionDto> PrescriptionRepository => new PrescriptionRepository(_context, _mapper, new[] { "User", "Medications" });
        //public IMedicationRepository MedicationRepository => new MedicationRepository(_context, _mapper);
        public IRepository<Medication, MedicationDto> MedicationRepository => new MedicationRepository(_context, _mapper, new[] { "Prescription", "MedicationSpreads" });
        //public IMedicationSpreadRepository MedicationSpreadRepository => new MedicationSpreadRepository(_context, _mapper);
        public IRepository<MedicationSpread, MedicationSpreadDto> MedicationSpreadRepository => new MedicationSpreadRepository(_context, _mapper, new[] { "Medication" });
        //public IMedicationReminderRepository MedicationReminderRepository => new MedicationReminderRepository(_context, _mapper);
        public IRepository<MedicationReminder, MedicationReminderDto> MedicationReminderRepository => new MedicationReminderRepository(_context, _mapper, new[] { "MedicationSpread" });
        //public IMedicationTimeRepository MedicationTimeRepository => new MedicationTimeRepository(_context, _mapper);
        public IRepository<MedicationTime, MedicationTimeDto> MedicationTimeRepository => new MedicationTimeRepository(_context, _mapper, new[] { "Spread" });
        //public IMoodRepository MoodRepository => new MoodRepository(_context, _mapper);
        public IRepository<Mood, MoodDto> MoodRepository => new MoodRepository(_context, _mapper, new[] { "MoodList", "ThoughtRecord" });
        //public IMoodListRepository MoodListRepository => new MoodListRepository(_context, _mapper);
        public IRepository<MoodList, MoodListDto> MoodListRepository => new MoodListRepository(_context, _mapper, new List<string>());
        //public IPlayListRepository PlayListRepository => new PlayListRepository(_context, _mapper);
        public IRepository<PlayList, PlayListDto> PlayListRepository => new PlayListRepository(_context, _mapper, new[] { "User" });
        //public ITrackRepository TrackRepository => new TrackRepository(_context, _mapper);
        public IRepository<Track, TrackDto> TrackRepository => new TrackRepository(_context, _mapper, new[] { "PlayList" });
        //public IAutomaticThoughtRepository AutomaticThoughtRepository => new AutomaticThoughtRepository(_context, _mapper);
        public IRepository<AutomaticThought, AutomaticThoughtDto> AutomaticThoughtRepository => new AutomaticThoughtRepository(_context, _mapper, new[] { "ThoughtRecord" });
        //public IActivitiesRepository ActivitiesRepository => new ActivitiesRepository(_context, _mapper);
        public IRepository<Activities, ActivityDto> ActivitiesRepository => new ActivitiesRepository(_context, _mapper, new[] { "User" });
        //public IActivityTimesRepository ActivityTimesRepository => new ActivityTimeRepository(_context, _mapper);
        public IRepository<ActivityTimes, ActivityTimeDto> ActivityTimesRepository => new ActivityTimeRepository(_context, _mapper, new[] { "Activity" });
        //public IContactRepository ContactRepository => new ContactRepository(_context, _mapper);
        public IRepository<Contact, ContactDto> ContactRepository => new ContactRepository(_context, _mapper, new[] { "User" });
        //public IEvidenceAgainstHotThoughtRepository EvidenceAgainstHotThoughtRepository => new EvidenceAgainstHotThoughtRepository(_context, _mapper);
        public IRepository<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto> EvidenceAgainstHotThoughtRepository => new EvidenceAgainstHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });
        //public IEvidenceForHotThoughtRepository EvidenceForHotThoughtRepository => new EvidenceForHotThoughtRepository(_context, _mapper);
        public IRepository<EvidenceForHotThought, EvidenceForHotThoughtDto> EvidenceForHotThoughtRepository => new EvidenceForHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });
        //public IReRateMoodRepository ReRateMoodRepository => new ReRateMoodRepository(_context, _mapper);
        public IRepository<ReRateMood, ReRateMoodDto> ReRateMoodRepository => new ReRateMoodRepository(_context, _mapper, new[] { "ThoughtRecord", "Mood" });
        //public ISituationRepository SituationRepository => new SituationRepository(_context, _mapper);
        public IRepository<Situation, SituationDto> SituationRepository => new SituationRepository(_context, _mapper, new[] { "ThoughtRecord" });
        //public IProblemRepository ProblemRepository => new ProblemRepository(_context, _mapper);
        public IRepository<Problem, ProblemDto> ProblemRepository => new ProblemRepository(_context, _mapper, new[] { "User", "Steps" });
        //public IProblemStepRepository ProblemStepRepository => new ProblemStepRepository(_context, _mapper);
        public IRepository<ProblemStep, ProblemStepDto> ProblemStepRepository => new ProblemStepRepository(_context, _mapper, new[] { "Problem", "Ideas" });

        public IRepository<ThoughtRecord, ThoughtRecordDto> ThoughtRecordRepository => new ThoughtRecordRepository(_context, _mapper, new[] { "User" });

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
