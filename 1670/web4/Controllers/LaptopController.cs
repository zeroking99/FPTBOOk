using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web4.Models;

namespace web4.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            //khởi tạo List với data type là Laptop (model)
            //gán dữ liệu ban đầu cho List
            List<Laptop> laptopList = new List<Laptop>()
            {
                new Laptop { Name = "Macbook Pro" , Price = 2000.50, Quantity = 100, Image = "macbook.jpeg" },
                new Laptop { Name = "Dell XPS", Quantity = 50, Price = 1250.88, Image = "dell.jpg"}
            };

            //add thêm dữ liệu vào List
            laptopList.Add(
                new Laptop { Name = "Asus Zenbook", Price = 1500.99, Quantity = 68, Image = "asus.jpg" }
             );

            //render ra View (Front-end) và gửi kèm dữ liệu (model List<Laptop>)
            return View(laptopList);
        }
    }
}
