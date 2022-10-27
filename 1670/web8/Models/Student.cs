using System.ComponentModel.DataAnnotations;

namespace web8.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Tên không được để trống")]
        [MinLength(3, ErrorMessage = "Tên tối thiểu phải có 3 ký tự")]
        [MaxLength(15, ErrorMessage = "Độ dài tối đa là 15 ký tự")]
        public string Name { get; set; }

        [Range(18,23, ErrorMessage = "Tuổi phải từ 18 đến 23")]
        public int Age { get; set; }

        [EmailAddress (ErrorMessage = "Yêu cầu điền đúng địa chỉ email")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Điền địa chỉ URL của ảnh vào đây")]
        public string Image { get; set; }

        [Phone (ErrorMessage = "Nhập số điện thoại")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại bắt buộc phải có 10 chữ số")]
        public string Mobile { get; set; }  
    }
}
