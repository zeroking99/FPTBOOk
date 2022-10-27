using demo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace demo.Controllers
{
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext context;

        public UniversityController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var universities = context.Universities.ToList();
            return View(universities);
        }

        public IActionResult Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var university = context.Universities
                                    .Include(u => u.Students)
                                    .FirstOrDefault(u => u.Id == id);
            //Note: khi muốn truy xuất dữ liệu của bảng B từ bảng A
            //thì cần sử dụng Include kết hợp với FirstOrDefault
            //còn nếu chỉ truy xuất thông tin id đơn thuần thì sử dụng
            //Find hoặc FirstOrDefault đều được
            return View(university);
        }
    }
}
