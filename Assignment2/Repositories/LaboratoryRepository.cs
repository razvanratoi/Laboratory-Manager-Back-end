using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Repositories
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratoryRepository
    {
        private readonly DataContext _context;
        public LaboratoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}