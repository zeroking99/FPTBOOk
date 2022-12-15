using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;

        }
        [Route("/")]
        public IActionResult Index()
        {
            
            return View(context.Books.ToList());

        }
        
        [HttpGet]
        [Authorize(Roles = "Administrator,Storner")]
        public IActionResult Create()
        {
            var category = context.Categories.ToList();
            ViewBag.Categories = category;
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator,Storner")]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Book_Category(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books.ToList().Where(b => b.CategoryId == id);
            ViewBag.Books = book;
            return View();
        }
       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books.Find(id);
            var category = context.Categories.ToList();
            ViewBag.Categories = category;
            return View(book);
        }

        [HttpPost]
       
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
      
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
 
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books
                .Include(c => c.Category)
                .FirstOrDefault(m => m.Id == id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Index(string BookSearch)
        {

            var books = context.Books.Where(boo => boo.Name.Contains(BookSearch)).ToList();
            if (books.Count == 0)
            {
                TempData["Mesage"] = "No Book";
            }
            return View("Index", books);
        }




    }
}
