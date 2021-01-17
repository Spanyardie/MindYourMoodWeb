using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Activities, ActivityDto>();
            CreateMap<ActivityTimes, ActivityTimeDto>();
            CreateMap<Affirmation, AffirmationDto>();
            CreateMap<AlternativeThought, AlternativeThoughtDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentQuestion, AppointmentQuestionDto>();
            CreateMap<Attitude, AttitudeDto>();
            CreateMap<AutomaticThought, AutomaticThoughtDto>();
            CreateMap<ChuffChartItem, ChuffChartItemDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<Fantasy, FantasyDto>();
            CreateMap<Feeling, FeelingDto>();
            CreateMap<GenericText, GenericTextDto>();
            CreateMap<Health, HealthDto>();
            CreateMap<EvidenceForHotThought, EvidenceForHotThoughtDto>();
            CreateMap<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto>();
            CreateMap<Image, ImageDto>();
            CreateMap<Medication, MedicationDto>();
            CreateMap<MedicationReminder, MedicationReminderDto>();
            CreateMap<MedicationSpread, MedicationSpreadDto>();
            CreateMap<MedicationTime, MedicationTimeDto>();
            CreateMap<Mood, MoodDto>();
            CreateMap<MoodList, MoodListDto>();
            CreateMap<PlayList, PlayListDto>();
            CreateMap<Prescription, PrescriptionDto>();
            CreateMap<Problem, ProblemDto>();
            CreateMap<ProblemIdea, ProblemIdeaDto>();
            CreateMap<ProblemProCon, ProblemProConDto>();
            CreateMap<ProblemStep, ProblemStepDto>();
            CreateMap<Reaction, ReactionDto>();
            CreateMap<Relationship, RelationshipDto>();
            CreateMap<ReRateMood, ReRateMoodDto>();
            CreateMap<SafetyPlanCard, SafetyPlanCardDto>();
            CreateMap<Situation, SituationDto>();
            CreateMap<SolutionPlan, SolutionPlanDto>();
            CreateMap<SolutionReview, SolutionReviewDto>();
            CreateMap<TellMyself, TellMyselfDto>();
            CreateMap<ThoughtRecord, ThoughtRecordDto>();
            CreateMap<Track, TrackDto>();
        }
    }
}
