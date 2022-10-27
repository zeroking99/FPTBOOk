using Microsoft.AspNetCore.Mvc;

namespace web3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
