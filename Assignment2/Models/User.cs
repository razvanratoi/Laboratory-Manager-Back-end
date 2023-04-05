using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public int? Group { get; set; }
        public string Hobby { get; set; } = "";
        public string Role { get; set; } = "";
    }
}