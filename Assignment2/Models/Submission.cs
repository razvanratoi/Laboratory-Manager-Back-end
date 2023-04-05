using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string GitLink { get; set; } = "";
        public string Comment { get; set; } = "";
        public float Grade { get; set; }
    }
}