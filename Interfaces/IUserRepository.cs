using MindYourMoodWeb.Entities;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<AppUser> GetUserByIdAsync(int id);
    }
}
