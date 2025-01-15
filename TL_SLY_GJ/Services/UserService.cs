using Microsoft.EntityFrameworkCore;
using TL_SLY_GJ.Models;

namespace TL_SLY_GJ.Services
{
    public class UserService
    {
        private TlSlyGjContext _context;
        public UserService(TlSlyGjContext context)
        {
            _context = context;
        }
        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Login(User user)
        {
            User foundUser = await _context.Users.FirstOrDefaultAsync(
                u => u.Email == user.Email && u.Password == user.Password);
            return foundUser != null;
        }
    }
}
