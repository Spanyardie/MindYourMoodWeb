using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Affirmation> AffirmationRepository { get; }
        IRepository<ChuffChartItem> ChuffChartRepository { get; }
        IRepository<AlternativeThought> AlternativeThoughtRepository { get; }
        IRepository<Appointment> AppointmentsRepository { get; }
        IRepository<AppointmentQuestion> AppointmentQuestionsRepository { get; }
        IRepository<Attitude> AttitudeRepository { get; }
        IRepository<Fantasy> FantasyRepository { get; }
        IRepository<Feeling> FeelingRepository { get; }
        IRepository<GenericText> GenericTextRepository { get; }
        IRepository<Health> HealthRepository { get; }
        IRepository<Prescription> PrescriptionRepository { get; }
        IRepository<Medication> MedicationRepository { get; }
        IRepository<MedicationSpread> MedicationSpreadRepository { get; }
        IRepository<MedicationReminder> MedicationReminderRepository { get; }
        IRepository<MedicationTime> MedicationTimeRepository { get; }
        IRepository<Mood> MoodRepository { get; }
        IRepository<MoodList> MoodListRepository { get; }
        IRepository<PlayList> PlayListRepository { get; }
        IRepository<AutomaticThought> AutomaticThoughtRepository { get; }
        IRepository<Activities> ActivitiesRepository { get; }
        IRepository<ActivityTimes> ActivityTimesRepository { get; }
        IRepository<Contact> ContactRepository { get; }
        IRepository<EvidenceAgainstHotThought> EvidenceAgainstHotThoughtRepository { get; }
        IRepository<EvidenceForHotThought> EvidenceForHotThoughtRepository { get; }
        IRepository<ReRateMood> ReRateMoodRepository { get; }
        IRepository<Situation> SituationRepository { get; }
        IRepository<Problem> ProblemRepository { get; }
        IRepository<ProblemStep> ProblemStepRepository { get; }
        IRepository<ProblemIdea> ProblemIdeaRepository { get; }
        IRepository<ProblemProCon> ProblemProConRepository { get; }
        IRepository<Reaction> ReactionRepository { get; }
        IRepository<Relationship> RelationshipRepository { get; }
        IRepository<SolutionReview> SolutionReviewRepository { get; }
        IRepository<SolutionPlan> SolutionPlanRepository { get; }
        IRepository<TellMyself> TellMyselfRepository { get; }
        IRepository<Track> TrackRepository { get; }
        IRepository<SafetyPlanCard> SafetyPlanCardRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<ThoughtRecord> ThoughtRecordRepository { get; }

        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
