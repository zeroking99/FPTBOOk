using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace web1.Controllers
{
    public class NetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Razor()
        {
            int age = 30;
            double grade = 7.5;
            bool isPassed = true;
            string name = "Greenwich";
            char c = 'a';
            //1. Pass dữ liệu từ Controller sang View bằng ViewBag
            ViewBag.Ten = name;
            ViewBag.City = "Ha Noi";
            ViewBag.Tuoi = age;

            //2. Pass dữ liệu từ Controller sang View bằng ViewData
            ViewData["Diem"] = grade;
            ViewData["Pass"] = isPassed;
            ViewData["KyTu"] = c;
            ViewData["Month"] = "September";
            
            return View();
        }
    }
}
