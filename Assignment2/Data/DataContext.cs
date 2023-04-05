using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Assignment> Assignments {get; set; } = default!;
        public DbSet<Attendance> Attendances {get; set; } = default!;
        public DbSet<Laboratory> Laboratories { get; set; } = default!;
        public DbSet<Submission> Submissions { get; set; } = default!;
        public DbSet<Token> Tokens { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
    }
}