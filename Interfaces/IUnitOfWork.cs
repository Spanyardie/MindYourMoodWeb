using System.Threading.Tasks;

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
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
