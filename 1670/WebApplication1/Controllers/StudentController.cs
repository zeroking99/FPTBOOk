using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        //attribute
        private readonly ApplicationDbContext context;

        //constructor (auto-generate : Alt+Enter => Generate constructor)
        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(context.Student.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                //nếu id không tìm thấy thì trả về not found
                return NotFound();
            }
            else
            {
                //tìm ra object student có id được yêu cầu
                var student = context.Student.Find(id);
                //xóa object student vừa tìm thấy
                context.Student.Remove(student);
                //lưu lại thay đổi trong db
                context.SaveChanges();
                //quay trở lại trang index sau khi thành công
                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Detail(int id)
        {
            var student = context.Student.Include(st => st.University).FirstOrDefault(st => st.Id == id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            context.Student.Add(student);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
