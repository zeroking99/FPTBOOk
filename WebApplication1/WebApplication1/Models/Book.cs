using System.ComponentModel.DataAnnotations;
using System;
namespace WebApplication1.Models
{   public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datee { get; set; }
        public bool BestSaler { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
