using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "This field cannot be empty!")]
        [MinLength(2, ErrorMessage = "Category name must have at least 2 characters!")]
        public string Name { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Url]
        [Display(Name = "Image")]
        public string Image { get; set; }

        
        public ICollection<Book> Books { get; set; }
    }
}
