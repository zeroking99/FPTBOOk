using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext _context)
        {
            context = _context;

        }
        public IActionResult Index()
        {
            var book = context.Books.ToList();
            return View(book);
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

        public IActionResult Create()
        {
            var category = context.Categories.ToList();
            ViewBag.Categories = category;
            return View();
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> Index(string BookSearch)
        {
            ViewData["GetBook"] = BookSearch;
            var query = from item in context.Books select item;
            if (!string.IsNullOrEmpty(BookSearch))
            {
                query = query.Where(b => b.Name.Contains(BookSearch));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
    }
}
