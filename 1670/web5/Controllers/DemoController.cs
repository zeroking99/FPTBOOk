using Microsoft.AspNetCore.Mvc;

namespace web5.Controllers
{
    public class DemoController : Controller
    {

        public IActionResult Input()
        {
            return View();
        }

        public IActionResult Output(string ten, int tuoi, string anh)
        {
            ViewData["Name"] = ten;
            ViewBag.Age = tuoi;
            ViewBag.Image = anh;
            return View();
        }
    }
}
