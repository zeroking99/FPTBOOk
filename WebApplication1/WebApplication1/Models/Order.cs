using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication1.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        public int Email { get; set; }
        public int BookId { get; set; }
        public Payment Payment { get; set; }
        public DateTime Order_Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
    public enum Payment
    {
        Visa, Mastercard, Napa, Cash
    }
}
