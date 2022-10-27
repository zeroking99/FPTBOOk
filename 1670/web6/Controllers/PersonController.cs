using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web6.Models;

namespace web6.Controllers
{
    public class PersonController : Controller
    {
        //khai báo và khởi tạo List<Person> để lưu dữ liệu từ form
        public static List<Person> persons = new List<Person>();

        //hiển thị toàn bộ dữ liệu từ List
        [Route("/")]
        public IActionResult Index()
        {
            return View(persons);
        }

        //add dữ liệu từ form (2 action):
        //1 action GET để render ra view form nhập liệu
   
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //1 action POST để xử lý dữ liệu từ form
        [HttpPost]
        public IActionResult Add(Person person)
        {
            //add dữ liệu từ model vào List
            persons.Add(person);
            //render ra trang index chứa list các Person
            //Cách 1 (return View): giữ nguyên đường dẫn + duplicate add nếu bấm F5 (Refresh)
            //return View("List", persons);
            //Cách 2 (RedirectToAction): thay đổi đường dẫn + không bị duplicate add khi bấm F5
            //(recommended)
            return RedirectToAction("Index",persons);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            persons.RemoveAt(id);
            return RedirectToAction("Index", persons);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = persons[id];
            //pass id của object person cần edit sang View
            ViewBag.Id = id;
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person newPerson, int id)
        {
            //override giá trị của object cũ bằng giá trị của object mới được nhập từ form
            var currentPerson = persons[id];
            currentPerson = newPerson;
            return RedirectToAction("Index", persons);
        }
    }
}
