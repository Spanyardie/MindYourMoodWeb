﻿using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IUnitOfWork
    {
        IAffirmationRepository AffirmationRepository { get; }
        IChuffChartRepository ChuffChartRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IAppointmentQuestionRepository AppointmentQuestionRepository { get; }
        IAttitudeRepository AttitudeRepository { get; }
        IFantasyRepository FantasyRepository { get; }
        IFeelingRepository FeelingRepository { get; }
        IGenericTextRepository GenericTextRepository { get; }
        IHealthRepository HealthRepository { get; }
        IPrescriptionRepository PrescriptionRepository { get; }
        IMedicationRepository MedicationRepository { get; }
        IMedicationSpreadRepository MedicationSpreadRepository { get; }
        IMedicationReminderRepository MedicationReminderRepository { get; }
        IMedicationTimeRepository MedicationTimeRepository { get; }
        IMoodRepository MoodRepository { get; }
        IMoodListRepository MoodListRepository { get; }
        IPlayListRepository PlayListRepository { get; }
        ITrackRepository TrackRepository { get; }
        
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
