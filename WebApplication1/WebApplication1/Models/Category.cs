using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class Category

    {
        public int Id { get; set; }    
        public string Name { get; set; }  
        public ICollection<Book> Books { get; set; }
    }
}
