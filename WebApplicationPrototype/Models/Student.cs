using System.ComponentModel.DataAnnotations;

namespace StudentAttributes.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}