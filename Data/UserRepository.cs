using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MindYourMoodWeb.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
