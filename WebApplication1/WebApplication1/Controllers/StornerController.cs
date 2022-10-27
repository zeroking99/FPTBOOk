using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StornerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
