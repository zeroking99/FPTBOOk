using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web3.Models;

namespace web3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentInfo()
        {
            //tạo object Student từ model Student
            var s1 = new Student();
            s1.Id = 1;
            s1.Name = "Minh";
            s1.Grade = 7.5;
            s1.Age = 20;
            s1.Image = "https://study2world.com/wp-content/uploads/2019/08/student.jpg";

            var s2 = new Student()
            {
                Id = 2,
                Age = 22,
                Name = "Hung",
                Grade = 8.2,
                Image = "https://content.gallup.com/origin/gallupinc/GallupSpaces/Production/Cms/EDUCMS/tz7n-7vqceaq86dprdnzag.jpg"
            };

            //pass dữ liệu sang View bằng model
            //Note: chỉ gửi được duy nhất 1 model sang 1 view
            return View(s1);
        }

        [Route("/list")]
        public IActionResult StudentList()
        {
            List<Student> students = new List<Student>() {
                new Student
                {
                    Id = 1,
                    Name = "Tuan",
                    Age = 19,
                    Grade = 8,
                    Image = "https://study2world.com/wp-content/uploads/2019/08/student.jpg"
                }, 
                new Student
                {
                    Id = 2,
                    Name = "Hung",
                    Age = 19,
                    Grade = 7,
                    Image = "https://study2world.com/wp-content/uploads/2019/08/student.jpg"
                }
            };
            students.Add(
                new Student
                {
                    Id = 3,
                    Name = "Tien",
                    Age = 19,
                    Grade = 9,
                    Image = "https://study2world.com/wp-content/uploads/2019/08/student.jpg"
                }
                );
            return View(students);
        }
    }
}
