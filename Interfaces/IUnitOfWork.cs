using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IUnitOfWork
    {
        //IAffirmationRepository AffirmationRepository { get; }
        IRepository<Affirmation, AffirmationDto> AffirmationRepository { get; }
        //IChuffChartRepository ChuffChartRepository { get; }
        IRepository<ChuffChartItem, ChuffChartItemDto> ChuffChartRepository { get; }
        //IAppointmentRepository AppointmentsRepository { get; }
        IRepository<Appointment, AppointmentDto> AppointmentsRepository { get; }
        //IAppointmentQuestionRepository AppointmentQuestionsRepository { get; }
        IRepository<AppointmentQuestion, AppointmentQuestionDto> AppointmentQuestionsRepository { get; }
        //IAttitudeRepository AttitudeRepository { get; }
        IRepository<Attitude, AttitudeDto> AttitudeRepository { get; }
        //IFantasyRepository FantasyRepository { get; }
        IRepository<Fantasy, FantasyDto> FantasyRepository { get; }
        //IFeelingRepository FeelingRepository { get; }
        IRepository<Feeling, FeelingDto> FeelingRepository { get; }
        //IGenericTextRepository GenericTextRepository { get; }
        IRepository<GenericText, GenericTextDto> GenericTextRepository { get; }
        //IHealthRepository HealthRepository { get; }
        IRepository<Health, HealthDto> HealthRepository { get; }
        //IPrescriptionRepository PrescriptionRepository { get; }
        IRepository<Prescription, PrescriptionDto> PrescriptionRepository { get; }
        //IMedicationRepository MedicationRepository { get; }
        IRepository<Medication, MedicationDto> MedicationRepository { get; }
        //IMedicationSpreadRepository MedicationSpreadRepository { get; }
        IRepository<MedicationSpread, MedicationSpreadDto> MedicationSpreadRepository { get; }
        //IMedicationReminderRepository MedicationReminderRepository { get; }
        IRepository<MedicationReminder, MedicationReminderDto> MedicationReminderRepository { get; }
        //IMedicationTimeRepository MedicationTimeRepository { get; }
        IRepository<MedicationTime, MedicationTimeDto> MedicationTimeRepository { get; }
        //IMoodRepository MoodRepository { get; }
        IRepository<Mood, MoodDto> MoodRepository { get; }
        //IMoodListRepository MoodListRepository { get; }
        IRepository<MoodList, MoodListDto> MoodListRepository { get; }
        //IPlayListRepository PlayListRepository { get; }
        IRepository<PlayList, PlayListDto> PlayListRepository { get; }
        //ITrackRepository TrackRepository { get; }
        IRepository<Track, TrackDto> TrackRepository { get; }
        //IAutomaticThoughtRepository AutomaticThoughtRepository { get; }
        IRepository<AutomaticThought, AutomaticThoughtDto> AutomaticThoughtRepository { get; }
        //IActivitiesRepository ActivitiesRepository { get; }
        IRepository<Activities, ActivityDto> ActivitiesRepository { get; }
        //IActivityTimesRepository ActivityTimesRepository { get; }
        IRepository<ActivityTimes, ActivityTimeDto> ActivityTimesRepository { get; }
        //IContactRepository ContactRepository { get; }
        IRepository<Contact, ContactDto> ContactRepository { get; }
        //IEvidenceAgainstHotThoughtRepository EvidenceAgainstHotThoughtRepository { get; }
        IRepository<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto> EvidenceAgainstHotThoughtRepository { get; }
        //IEvidenceForHotThoughtRepository EvidenceForHotThoughtRepository { get; }
        IRepository<EvidenceForHotThought, EvidenceForHotThoughtDto> EvidenceForHotThoughtRepository { get; }
        //IReRateMoodRepository ReRateMoodRepository { get; }
        IRepository<ReRateMood, ReRateMoodDto> ReRateMoodRepository { get; }
        //ISituationRepository SituationRepository { get; }
        IRepository<Situation, SituationDto> SituationRepository { get; }
        //IProblemRepository ProblemRepository { get; }
        IRepository<Problem, ProblemDto> ProblemRepository { get; }
        //IProblemStepRepository ProblemStepRepository { get; }
        IRepository<ProblemStep, ProblemStepDto> ProblemStepRepository { get; }

        IRepository<ThoughtRecord, ThoughtRecordDto> ThoughtRecordRepository { get; }

        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
