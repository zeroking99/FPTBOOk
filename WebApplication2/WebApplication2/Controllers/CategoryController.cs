using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
      
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            context = context;
        }
        public IActionResult Index()
        {
            var category = context.Categories.ToList();
            return View(category);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.FirstOrDefault(m => m.Id == id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
