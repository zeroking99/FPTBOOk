using Microsoft.AspNetCore.Mvc;
using web9.Models;

namespace web9.Controllers
{
    public class EmployeeController : Controller
    {
        //render ra form nhập dữ liệu
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //nhận và xử lý dữ liệu từ form
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            //check xem dữ liệu nhập vào có hợp lệ hay không
            //hợp lệ: có thỏa mãn các yêu cầu khai báo ở Model hay không
            
            //Bước 2: check trong Controller bằng hàm IsValid()
            if (ModelState.IsValid)
            {
                //nếu hợp lệ thì trả về view Result kèm dữ liệu của model
                return View("Result", emp);
            }
            //ngược lại trả về form nhập liệu kèm dữ liệu sai
            return View(emp);
        }

        public IActionResult Result (Employee emp)
        {
            return View(emp);
        }

        
    }
}
