using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Repositories
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        private readonly DataContext _context;
        public AttendanceRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetByLabId(int id)
        {
            return await _context.Attendances.Where(a => a.LabId == id).ToListAsync();
        }
    }
}