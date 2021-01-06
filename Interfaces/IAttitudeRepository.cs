using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IAttitudeRepository
    {
        void Update(Attitude attitude);
        Task<IEnumerable<AttitudeDto>> GetAttitudesAsync(int userId);
        Task<Attitude> GetAttitudeAsync(int attitudeId);
        void AddAttitude(Attitude attitudeItem);
        void RemoveAttitude(Attitude attitude);
    }
}
