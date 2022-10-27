using Microsoft.AspNetCore.Mvc;

namespace web1.Controllers
{
    public class DemoController : Controller
    {
        /* Mục đích: render ra file View
        nằm ở đường dẫn Views/Demo/Index.cshtml
        Demo : tên của Controller (class)
        Index : tên của Action (method) */
        [Route("/demo")]
        public IActionResult Index()
        {
            return View();
        }

        //set thành homepage
        [Route("/")]
        public IActionResult ApplicationDevelopment()
        {
            return View();
        }

        public IActionResult Demo()
        {
            //render view mặc định: Views/Demo/Demo.cshtml 
            //return View();
            //return View("~/Views/Demo/Demo.cshtml");

            //render view tùy biến: Views/Home/Demo.csthml
            return View("~/Views/Home/Demo.cshtml");
        }
    }
}
