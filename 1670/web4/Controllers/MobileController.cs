using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web4.Models;

namespace web4.Controllers
{
    public class MobileController : Controller
    {
        public IActionResult Index()
        {
            List<Mobile> mobiles = new List<Mobile>()
            {
                new Mobile{ Name = "iPhone 14 Pro Max", Brand = "Apple", Color = "Black", BestSeller = true, Image = "https://www.apple.com/newsroom/images/product/iphone/standard/Apple-iPhone-14-Pro-iPhone-14-Pro-Max-deep-purple-220907_inline.jpg.large.jpg"},
                new Mobile{ Name = "Galaxy S22 Ultra", Brand = "Samsung", Color = "Blue", BestSeller = true, Image = "https://didongviet.vn/dchannel/wp-content/uploads/2022/03/s22-ultra-mau-xanh-la-01.jpg"},
                new Mobile{ Name = "Find X3 Pro", Brand = "Oppo", Color = "White", BestSeller = false, Image = "https://genk.mediacdn.vn/139269124445442048/2021/2/18/photo-1-16136363473661727479014.jpg"}
            };
            return View(mobiles);
        }
    }
}
