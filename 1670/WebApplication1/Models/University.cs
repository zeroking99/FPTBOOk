using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    //relationship university - student : one -many
    public class University
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Logo { get; set; }
        //khai báo ICollection để kết nối đến student từ university
        public ICollection<Student> Student { get; set; }
    }
}
