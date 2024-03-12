using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCrud.Models
{
    [Table("Std")]
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Standard { get; set; }

        [Required]
        public string? FeeRecord { get; set; }





    }
}
