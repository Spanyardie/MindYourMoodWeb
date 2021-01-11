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

        public IRepository<Affirmation, AffirmationDto> AffirmationRepository => new AffirmationRepository(_context, _mapper, new[] { "User" });

        public IRepository<ChuffChartItem, ChuffChartItemDto> ChuffChartRepository => new ChuffChartRepository(_context, _mapper, new[] { "User" });

        public IRepository<Appointment, AppointmentDto> AppointmentsRepository => new AppointmentRepository(_context, _mapper, new[] { "User" });

        public IRepository<AppointmentQuestion, AppointmentQuestionDto> AppointmentQuestionsRepository => new AppointmentQuestionRepository(_context, _mapper, new[] { "Appointment" });

        public IRepository<Attitude, AttitudeDto> AttitudeRepository => new AttitudeRepository(_context, _mapper, new[] { "User" });

        public IRepository<Fantasy, FantasyDto> FantasyRepository => new FantasyRepository(_context, _mapper, new[] { "User" });

        public IRepository<Feeling, FeelingDto> FeelingRepository => new FeelingRepository(_context, _mapper, new[] { "User" });

        public IRepository<GenericText, GenericTextDto> GenericTextRepository => new GenericTextRepository(_context, _mapper, new[] { "User" });

        public IRepository<Health, HealthDto> HealthRepository => new HealthRepository(_context, _mapper, new[] { "User" });

        public IRepository<Prescription, PrescriptionDto> PrescriptionRepository => new PrescriptionRepository(_context, _mapper, new[] { "User", "Medications" });

        public IRepository<Medication, MedicationDto> MedicationRepository => new MedicationRepository(_context, _mapper, new[] { "Prescription", "MedicationSpreads" });

        public IRepository<MedicationSpread, MedicationSpreadDto> MedicationSpreadRepository => new MedicationSpreadRepository(_context, _mapper, new[] { "Medication" });

        public IRepository<MedicationReminder, MedicationReminderDto> MedicationReminderRepository => new MedicationReminderRepository(_context, _mapper, new[] { "MedicationSpread" });

        public IRepository<MedicationTime, MedicationTimeDto> MedicationTimeRepository => new MedicationTimeRepository(_context, _mapper, new[] { "Spread" });

        public IRepository<Mood, MoodDto> MoodRepository => new MoodRepository(_context, _mapper, new[] { "MoodList", "ThoughtRecord" });

        public IRepository<MoodList, MoodListDto> MoodListRepository => new MoodListRepository(_context, _mapper, new List<string>());

        public IRepository<PlayList, PlayListDto> PlayListRepository => new PlayListRepository(_context, _mapper, new[] { "User" });

        public IRepository<AutomaticThought, AutomaticThoughtDto> AutomaticThoughtRepository => new AutomaticThoughtRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<Activities, ActivityDto> ActivitiesRepository => new ActivitiesRepository(_context, _mapper, new[] { "User" });

        public IRepository<ActivityTimes, ActivityTimeDto> ActivityTimesRepository => new ActivityTimeRepository(_context, _mapper, new[] { "Activity" });

        public IRepository<Contact, ContactDto> ContactRepository => new ContactRepository(_context, _mapper, new[] { "User" });

        public IRepository<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto> EvidenceAgainstHotThoughtRepository => new EvidenceAgainstHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });

        public IRepository<EvidenceForHotThought, EvidenceForHotThoughtDto> EvidenceForHotThoughtRepository => new EvidenceForHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });

        public IRepository<ReRateMood, ReRateMoodDto> ReRateMoodRepository => new ReRateMoodRepository(_context, _mapper, new[] { "ThoughtRecord", "Mood" });

        public IRepository<Situation, SituationDto> SituationRepository => new SituationRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<Problem, ProblemDto> ProblemRepository => new ProblemRepository(_context, _mapper, new[] { "User", "Steps" });

        public IRepository<ProblemStep, ProblemStepDto> ProblemStepRepository => new ProblemStepRepository(_context, _mapper, new[] { "Problem", "Ideas" });

        public IRepository<ProblemIdea, ProblemIdeaDto> ProblemIdeaRepository => new ProblemIdeaRepository(_context, _mapper, new[] { "Step", "Problem" });

        public IRepository<ProblemProCon, ProblemProConDto> ProblemProConRepository => new ProblemProConRepository(_context, _mapper, new[] { "Problem", "Step", "Idea" });

        public IRepository<Reaction, ReactionDto> ReactionRepository => new ReactionRepository(_context, _mapper, new[] { "User" });

        public IRepository<Relationship, RelationshipDto> RelationshipRepository => new RelationshipRepository(_context, _mapper, new[] { "User" });

        public IRepository<SolutionReview, SolutionReviewDto> SolutionReviewRepository => new SolutionReviewRepository(_context, _mapper, new[] { "Idea", "SolutionSteps" });

        public IRepository<SolutionPlan, SolutionPlanDto> SolutionPlanRepository => new SolutionPlanRepository(_context, _mapper, new[] { "SolutionReview" });

        public IRepository<TellMyself, TellMyselfDto> TellMyselfRepository => new TellMyselfRepository(_context, _mapper, new[] { "User" });

        public IRepository<Track, TrackDto> TrackRepository => new TrackRepository(_context, _mapper, new[] { "PlayList" });

        public IRepository<AlternativeThought, AlternativeThoughtDto> AlternativeThoughtRepository => new AlternativeThoughtRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<ThoughtRecord, ThoughtRecordDto> ThoughtRecordRepository => new ThoughtRecordRepository(_context, _mapper, new[] { "User" });

        public IRepository<SafetyPlanCard, SafetyPlanCardDto> SafetyPlanCardRepository => new SafetyPlanCardRepository(_context, _mapper, new[] { "User" });

        public IRepository<Image, ImageDto> ImageRepository => new ImageRepository(_context, _mapper, new[] { "User" });

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
