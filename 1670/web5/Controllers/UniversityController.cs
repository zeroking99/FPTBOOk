using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web5.Models;

namespace web5.Controllers
{
    public class UniversityController : Controller
    {
        public static List<University> universities = new List<University>();

        //render ra view form để nhập liệu
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //xử lý dữ liệu nhập từ form
        [HttpPost]
        public IActionResult Index(University uni)
        {        
            universities.Add(uni);
            return View("Result", universities);
        }
    }
}
