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

        public IRepository<Affirmation> AffirmationRepository => new AffirmationRepository(_context, _mapper, new[] { "User" });

        public IRepository<ChuffChartItem> ChuffChartRepository => new ChuffChartRepository(_context, _mapper, new[] { "User" });

        public IRepository<Appointment> AppointmentsRepository => new AppointmentRepository(_context, _mapper, new[] { "User" });

        public IRepository<AppointmentQuestion> AppointmentQuestionsRepository => new AppointmentQuestionRepository(_context, _mapper, new[] { "Appointment" });

        public IRepository<Attitude> AttitudeRepository => new AttitudeRepository(_context, _mapper, new[] { "User" });

        public IRepository<Fantasy> FantasyRepository => new FantasyRepository(_context, _mapper, new[] { "User" });

        public IRepository<Feeling> FeelingRepository => new FeelingRepository(_context, _mapper, new[] { "User" });

        public IRepository<GenericText> GenericTextRepository => new GenericTextRepository(_context, _mapper, new[] { "User" });

        public IRepository<Health> HealthRepository => new HealthRepository(_context, _mapper, new[] { "User" });

        public IRepository<Prescription> PrescriptionRepository => new PrescriptionRepository(_context, _mapper, new[] { "User", "Medications" });

        public IRepository<Medication> MedicationRepository => new MedicationRepository(_context, _mapper, new[] { "Prescription", "MedicationSpreads" });

        public IRepository<MedicationSpread> MedicationSpreadRepository => new MedicationSpreadRepository(_context, _mapper, new[] { "Medication" });

        public IRepository<MedicationReminder> MedicationReminderRepository => new MedicationReminderRepository(_context, _mapper, new[] { "MedicationSpread" });

        public IRepository<MedicationTime> MedicationTimeRepository => new MedicationTimeRepository(_context, _mapper, new[] { "Spread" });

        public IRepository<Mood> MoodRepository => new MoodRepository(_context, _mapper, new[] { "MoodList", "ThoughtRecord" });

        public IRepository<MoodList> MoodListRepository => new MoodListRepository(_context, _mapper, new List<string>());

        public IRepository<PlayList> PlayListRepository => new PlayListRepository(_context, _mapper, new[] { "User" });

        public IRepository<AutomaticThought> AutomaticThoughtRepository => new AutomaticThoughtRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<Activities> ActivitiesRepository => new ActivitiesRepository(_context, _mapper, new[] { "User" });

        public IRepository<ActivityTimes> ActivityTimesRepository => new ActivityTimeRepository(_context, _mapper, new[] { "Activity" });

        public IRepository<Contact> ContactRepository => new ContactRepository(_context, _mapper, new[] { "User" });

        public IRepository<EvidenceAgainstHotThought> EvidenceAgainstHotThoughtRepository => new EvidenceAgainstHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });

        public IRepository<EvidenceForHotThought> EvidenceForHotThoughtRepository => new EvidenceForHotThoughtRepository(_context, _mapper, new[] { "AutomaticThought", "ThoughtRecord" });

        public IRepository<ReRateMood> ReRateMoodRepository => new ReRateMoodRepository(_context, _mapper, new[] { "ThoughtRecord", "Mood" });

        public IRepository<Situation> SituationRepository => new SituationRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<Problem> ProblemRepository => new ProblemRepository(_context, _mapper, new[] { "User", "Steps" });

        public IRepository<ProblemStep> ProblemStepRepository => new ProblemStepRepository(_context, _mapper, new[] { "Problem", "Ideas" });

        public IRepository<ProblemIdea> ProblemIdeaRepository => new ProblemIdeaRepository(_context, _mapper, new[] { "Step", "Problem" });

        public IRepository<ProblemProCon> ProblemProConRepository => new ProblemProConRepository(_context, _mapper, new[] { "Problem", "Step", "Idea" });

        public IRepository<Reaction> ReactionRepository => new ReactionRepository(_context, _mapper, new[] { "User" });

        public IRepository<Relationship> RelationshipRepository => new RelationshipRepository(_context, _mapper, new[] { "User" });

        public IRepository<SolutionReview> SolutionReviewRepository => new SolutionReviewRepository(_context, _mapper, new[] { "Idea", "SolutionSteps" });

        public IRepository<SolutionPlan> SolutionPlanRepository => new SolutionPlanRepository(_context, _mapper, new[] { "SolutionReview" });

        public IRepository<TellMyself> TellMyselfRepository => new TellMyselfRepository(_context, _mapper, new[] { "User" });

        public IRepository<Track> TrackRepository => new TrackRepository(_context, _mapper, new[] { "PlayList" });

        public IRepository<AlternativeThought> AlternativeThoughtRepository => new AlternativeThoughtRepository(_context, _mapper, new[] { "ThoughtRecord" });

        public IRepository<ThoughtRecord> ThoughtRecordRepository => new ThoughtRecordRepository(_context, _mapper, new[] { "User" });

        public IRepository<SafetyPlanCard> SafetyPlanCardRepository => new SafetyPlanCardRepository(_context, _mapper, new[] { "User" });

        public IRepository<Image> ImageRepository => new ImageRepository(_context, _mapper, new[] { "User" });

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
