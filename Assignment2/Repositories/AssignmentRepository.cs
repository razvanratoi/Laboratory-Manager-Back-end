using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Repositories
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        private readonly DataContext _context;
        public AssignmentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}