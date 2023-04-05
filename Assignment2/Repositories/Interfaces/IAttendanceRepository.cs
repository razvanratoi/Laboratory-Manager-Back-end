using Assignment2.Models;

namespace Assignment2.Repositories.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetByLabId(int id);
    }
}