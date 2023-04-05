using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public int LabId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }
    }
    
}