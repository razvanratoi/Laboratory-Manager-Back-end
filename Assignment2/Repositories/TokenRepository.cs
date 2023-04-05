using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Repositories
{
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        private readonly DataContext _context;
        public TokenRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Token?> GetTokenByValue(string value)
        {
           return _context.Tokens.FirstOrDefaultAsync( t => t.Value == value);
        }
    }
}