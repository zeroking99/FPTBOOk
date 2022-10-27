using Microsoft.AspNetCore.Mvc;

namespace web5.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Check(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            //if (username == "admin" && password == "123456")
            //{
            //    ViewBag.Result = true;
            //} else
            //{
            //    ViewBag.Result = false;
            //}
            return View();
        }
    }
}
