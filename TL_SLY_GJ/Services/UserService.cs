using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public async Task<bool> Register(User user)
        {
            if (await Login(user) != -1)
            {
                return false;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> Login(User user)
        {
            User? foundUser = await _context.Users.FirstOrDefaultAsync(
                u => u.Email == user.Email && u.Password == user.Password);
            if (foundUser != null)
            {
                return foundUser.UserId;
            }
            return -1;
        }

        public async Task<string> GetEmail(int userid)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userid);
            if (user != null)
            {
                return user.Email;
            }
            return "";
        }
    }
}
