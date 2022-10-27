using System.ComponentModel.DataAnnotations;
using System.Data;

namespace web10.Models
{
    //tạo class Model để đại diện cho bảng trong DB
    //thuộc tính của class chính là cột ở trong bảng
    public class Product
    {
        public int Id { get; set; }
        
        [StringLength(20, ErrorMessage = "Product name must be 5 to 20 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Range(10,1000, ErrorMessage = "Min price is 10, max price is 1000")]
        public double Price { get; set; }

        [Range(1, 500, ErrorMessage = "Quantity is from 1 to 500")]
        public int Quantity { get; set; }

        [Required]
        [MinLength(10)]
        public string Image { get; set; }

        [Required]
        public string Color { get; set; }
    }
}
