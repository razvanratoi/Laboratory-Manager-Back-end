using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Token
    {
        public Token(string value)
        {
            this.Value = value;
        }

        [Key]
        public int Id { get; set; }
        public string Value { get; set; } = "";
    }
}