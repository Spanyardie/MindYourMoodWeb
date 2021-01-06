using MindYourMoodWeb.Entities;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
