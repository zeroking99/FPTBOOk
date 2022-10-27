using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext context;

        public UniversityController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            var universities = context.Universities.ToList();
            return View(universities);
        }
        public IActionResult Info(int? id)
        {
            if(id==null){

                return NotFound();
            }
            var universities = context.Universities.Include(u=> u.Student).FirstOrDefault(u=>u.Id ==id);
            return View(universities);
        }
    }
}
