using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Laboratory
    {
        [Key]
        public int Id { get; set; }
        public int LabNb { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = "";
        public string Curricula { get; set; } = "";
        public string Description { get; set; } = "";
    }
}