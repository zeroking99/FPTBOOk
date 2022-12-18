using System.Collections.Generic;
namespace WebApplication1.Models
{
    public class Category

    {
        public int Id { get; set; }    
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<Book> Books { get; set; }
    }
     
    
}
