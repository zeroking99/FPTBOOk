using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    
        public string Image { get; set; }
    }
}
