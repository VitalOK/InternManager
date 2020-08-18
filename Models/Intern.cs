using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Intern
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var years = DateTime.Now.Subtract(DateOfBirth);
                return years.Days / 365;
            }
        }
    }
}
