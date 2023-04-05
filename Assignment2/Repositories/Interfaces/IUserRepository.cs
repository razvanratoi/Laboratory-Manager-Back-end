using Assignment2.Models;

namespace Assignment2.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
         Task<User?> GetUserByCredentials(string username, string password);
         Task<User?> GetUserByEmail(string email);
    }
}