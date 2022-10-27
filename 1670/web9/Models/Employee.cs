using System;
using System.ComponentModel.DataAnnotations;
using web9.Validation;

namespace web9.Models
{
    public class Employee
    {  
        //Cần 3 bước để có thể validate dữ liệu từ form
        //Bước 1: set DataAnnotation trong Model
        [StringLength(30, ErrorMessage = "Độ dài tên phải từ 5 đến 30", MinimumLength = 5)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ngày tháng năm sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Chức vụ không được để trống")]
        public string Position { get; set; }

        [Range (100, 3000, ErrorMessage = "Lương phải từ 100$ đến 3000$")]
        public double Salary { get; set; }

        [MinLength(5, ErrorMessage = "Địa chỉ tối thiểu là 5 ký tự")]
        [MaxLength(50, ErrorMessage = "Địa chỉ tối đa là 50 ký tự")]
        public string Address { get; set; }
    }
}
