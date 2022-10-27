using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace web2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Demo()
        {
            return View();
        }

        public IActionResult PassData()
        {
            var year = DateTime.Now.Year;
            var yob = 1995;
            var age = year - yob;
            var gen = 'M';
            var gender = "";
            if (gen == 'M' || gen == 'm')
            {
                gender = "Male";
            } else if (gen == 'F' || gen == 'f')
            {
                gender = "Female";
            } else
            {
                gender = "LGBT";
            }

            List<String> names = new List<string>()
            {
                "Minh", "Huong", "Tien", "Hoang", "Hung"
            };
            names.Add("Nam");
            names.Add("Phuong");

            //Cách 1: Dùng ViewData để gửi dữ liệu sang View
            ViewData["Age"] = age;
            ViewData["Gender"] = gender;
            ViewData["Phone"] = "0912345678";
            //Cách 2: Dùng ViewBag để gửi dữ liệu sang View
            ViewBag.Students = names;

            return View();
        }
    }
}
