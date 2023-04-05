using Assignment2.Models;

namespace Assignment2.Repositories.Interfaces
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        Task<Token?> GetTokenByValue(string value);
    }
}