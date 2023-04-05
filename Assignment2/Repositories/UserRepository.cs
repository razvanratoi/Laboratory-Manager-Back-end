using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByCredentials(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username &&
                                                    u.Password == password);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}