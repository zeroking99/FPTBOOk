using Microsoft.AspNetCore.Mvc;

namespace web2.Controllers
{
    public class TestController : Controller
    {
        //set trang home
        [Route("/")]
        public IActionResult Index()
        {
            //Location: Views/Test/Index.cshtml
            //Tên của Controller => Tên thư mục trong Views
            //Tên của Action => Tên file view (cshtml)
            return View();
        }

        public IActionResult HaNoi()
        {
            //tùy biến đường dẫn và tên file View (thay vì dùng mặc định)
            return View("~/Views/Greenwich/HN.cshtml");
        }

        public IActionResult CanTho()
        {
            return View();
        }

        public IActionResult DaNang()
        {
            return View();
        }
    }
}
