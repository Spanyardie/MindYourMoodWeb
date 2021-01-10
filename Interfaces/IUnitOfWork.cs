using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Affirmation, AffirmationDto> AffirmationRepository { get; }
        IRepository<ChuffChartItem, ChuffChartItemDto> ChuffChartRepository { get; }
        IRepository<Appointment, AppointmentDto> AppointmentsRepository { get; }
        IRepository<AppointmentQuestion, AppointmentQuestionDto> AppointmentQuestionsRepository { get; }
        IRepository<Attitude, AttitudeDto> AttitudeRepository { get; }
        IRepository<Fantasy, FantasyDto> FantasyRepository { get; }
        IRepository<Feeling, FeelingDto> FeelingRepository { get; }
        IRepository<GenericText, GenericTextDto> GenericTextRepository { get; }
        IRepository<Health, HealthDto> HealthRepository { get; }
        IRepository<Prescription, PrescriptionDto> PrescriptionRepository { get; }
        IRepository<Medication, MedicationDto> MedicationRepository { get; }
        IRepository<MedicationSpread, MedicationSpreadDto> MedicationSpreadRepository { get; }
        IRepository<MedicationReminder, MedicationReminderDto> MedicationReminderRepository { get; }
        IRepository<MedicationTime, MedicationTimeDto> MedicationTimeRepository { get; }
        IRepository<Mood, MoodDto> MoodRepository { get; }
        IRepository<MoodList, MoodListDto> MoodListRepository { get; }
        IRepository<PlayList, PlayListDto> PlayListRepository { get; }
        IRepository<AutomaticThought, AutomaticThoughtDto> AutomaticThoughtRepository { get; }
        IRepository<Activities, ActivityDto> ActivitiesRepository { get; }
        IRepository<ActivityTimes, ActivityTimeDto> ActivityTimesRepository { get; }
        IRepository<Contact, ContactDto> ContactRepository { get; }
        IRepository<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto> EvidenceAgainstHotThoughtRepository { get; }
        IRepository<EvidenceForHotThought, EvidenceForHotThoughtDto> EvidenceForHotThoughtRepository { get; }
        IRepository<ReRateMood, ReRateMoodDto> ReRateMoodRepository { get; }
        IRepository<Situation, SituationDto> SituationRepository { get; }
        IRepository<Problem, ProblemDto> ProblemRepository { get; }
        IRepository<ProblemStep, ProblemStepDto> ProblemStepRepository { get; }
        IRepository<ProblemIdea, ProblemIdeaDto> ProblemIdeaRepository { get; }
        IRepository<ProblemProCon, ProblemProConDto> ProblemProConRepository { get; }
        IRepository<Reaction, ReactionDto> ReactionRepository { get; }
        IRepository<Relationship, RelationshipDto> RelationshipRepository { get; }
        IRepository<SolutionReview, SolutionReviewDto> SolutionReviewRepository { get; }
        IRepository<SolutionPlan, SolutionPlanDto> SolutionPlanRepository { get; }
        IRepository<TellMyself, TellMyselfDto> TellMyselfRepository { get; }
        IRepository<Track, TrackDto> TrackRepository { get; }

        IRepository<ThoughtRecord, ThoughtRecordDto> ThoughtRecordRepository { get; }

        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
