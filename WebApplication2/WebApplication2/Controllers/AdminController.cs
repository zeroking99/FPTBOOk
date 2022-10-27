using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using System.Linq;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public IActionResult Index()
        {
            var admins = context.Admins.ToList();
            return View(admins);
        }

    }
}
