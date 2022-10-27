using Microsoft.AspNetCore.Mvc;

namespace web3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
