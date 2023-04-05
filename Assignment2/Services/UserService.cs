using Assignment1.Services;
using Assignment2.Facilities;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Services
{
    public class UserService
    {
        private readonly ITokenRepository _tokenRepo;
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        public UserService(IUserRepository userRepo, ITokenRepository tokenRepo, IConfiguration config)
        {
            _config = config;
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
        }

        public string Login(LoginCredentials creds)
        {
            creds.Password = PasswordService.encryptPassword(creds.Password);
            var user = _userRepo.GetUserByCredentials(creds.Username, creds.Password).Result;
            if (user == null)
                return "";
            else
                return user.Role;
        }

        public bool Register(Credentials creds)
        {
            var token = _tokenRepo.GetTokenByValue(creds.Token);
            Console.Write(token);
            if (token == null)
                return false;
            else
            {
                User user = new User();
                user.Email = creds.Email;
                user.Hobby = creds.Hobby;
                user.Name = creds.Name;
                user.Username = creds.Username;
                user.Group = creds.Group;
                user.Password = PasswordService.encryptPassword(creds.Password);
                user.Role = "Student";
                return _userRepo.Add(user).Result;
            }
        }

        public string CreateStudent(string email)
        {
            TokenGenerator tg = new TokenGenerator(_config);
            var token =  tg.GenerateToken(email);
            _tokenRepo.Add(new Token(token));
            return token;
        }

        public bool UpdateUser(User user)
        {
            return _userRepo.Update(user).Result;
        }

        public bool CreateTeacher(User user)
        {
            return _userRepo.Add(user).Result;
        }

        public bool DeleteUser(string email)
        {
            var user = _userRepo.GetUserByEmail(email).Result;
            if (user != null) return _userRepo.Delete(user).Result;
            else return false;
        }

        public User? GetUser(string email)
        {
            return _userRepo.GetUserByEmail(email).Result;
        }

        public User? GetById(int id)
        {
            return _userRepo.GetById(id).Result;
        }
    }
}