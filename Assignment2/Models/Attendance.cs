using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LabId { get; set; }
    }
}