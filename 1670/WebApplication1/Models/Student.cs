using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication1.Models
{
    //realtionship student - university many -one
    public class Student
    {

        //primary key + auto increment
        public int Id { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Student ID must have 8 characters")]
        public string SId { get; set; }

        [MinLength(5, ErrorMessage = "Name length must be at least 5 characters")]
        [MaxLength(30, ErrorMessage = "Max name length is 30 characters")]
        public string Name { get; set; }

        //public int Age { get; set; }
        //public int BirthYear { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must have 10 digits")]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Grade must be from 0 to 10")]
        public double Grade { get; set; }

        [Required(ErrorMessage = "This information can not be ignored")]
        public bool IsGraduated { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        [Display(Name = "Avatar")]
        public string Image { get; set; }
        //foreign key : kết nối Id bảng university
        // chỉ sử đụng dể kết nối tỏng DB
        public int unId { get; set; }
        //tạo object dể sử dụng trong code
        public University University { get; set; }
    }
}
