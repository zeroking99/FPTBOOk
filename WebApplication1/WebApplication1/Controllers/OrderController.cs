using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext _context)
        {
            context = _context;
        }

       
        public IActionResult Index()
        {
            var order = context.Orders.ToList();
            return View(order);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = context.Orders
                .Include(b => b.Book)
                .Include(c => c.Customer)
                .FirstOrDefault(o => o.Id == id);
            return View(order);
        }

        public IActionResult Create(int? id)
        {
            var book = context.Books.Where(b => b.Id == id);
            ViewBag.Books = book;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            order.Order_Date = System.DateTime.Today;
            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
