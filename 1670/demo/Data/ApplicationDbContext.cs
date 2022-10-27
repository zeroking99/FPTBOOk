using demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace demo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //tạo bảng (DB) tương ứng model (Code)
        //Student: tên của Model (design của bảng)
        //Students: tên của bảng & tên của DbSet (collection) được gọi đến trong Controller
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Note: add dữ liệu cho bảng chứa PK trước (University)
            //rồi add dữ liệu cho bảng chứa FK sau (Student)

            //add dữ liệu khởi tạo cho bảng University
            PopulateUniversity(builder);

            //add dữ liệu khởi tạo (initial data) cho bảng Student
            SeedStudent(builder);          
        }

        private void PopulateUniversity(ModelBuilder builder)
        {
            var greenwich = new University { Id = 10, Name = "Greenwich", Address = "Pham Van Bach", 
                Logo = "https://career.fpt.edu.vn/Content/images/logo_unit/2017-Greenwich-Eng-01.png"
            };
            var swinburne = new University
            {
                Id = 30,
                Name = "Swinburne",
                Address = "Duy Tan",
                Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRz0i0yB35olWXOJ31vj9z53-VQY0U6cpk4GRhIbOZ21Wbw3UIyWyDZeMQKd2flQHeVxyQ&usqp=CAU"
            };
            builder.Entity<University>().HasData(greenwich, swinburne);
        }

        private void SeedStudent (ModelBuilder builder)
        {
            //add dữ liệu tự động vào DB bằng code
            builder.Entity<Student>().HasData(
                //bắt buộc phải nhập giá trị cho cột Id (PK)
                //những thuộc tính set là "Required" ở trong file Model thì bắt buộc phải nhập
                //còn lại không bắt buộc. Thứ tự khai báo các thuộc tính không quan trọng
                new Student
                {
                    Id = 1, //Id không cần phải bắt đầu từ 1 (gõ tùy ý nhưng giá trị phải khác nhau)
                    UniversityId = 10, //UniversityId phải tồn tại ở trong bảng University
                    Name = "Nam",
                    Mobile = "0912345678",
                    Email = "nam@gmail.com",
                    Gender = 'M',
                    Grade = 7.8,
                    IsGraduated = true,
                    SId = "GCH12345",
                    Image = "https://d2jyir0m79gs60.cloudfront.net/news/images/successful-college-student-lg.png",
                    Birthday = DateTime.Parse("2000-04-06")  //YYYY-MM-DD
                },
                new Student
                {
                    Id = 2,
                    UniversityId = 30,
                    Name = "Huong",
                    Mobile = "0912345678",
                    Email = "nam@gmail.com",
                    Gender = 'F',
                    Grade = 7.8,
                    IsGraduated = true,
                    SId = "GCH12345",
                    Image = "https://content.gallup.com/origin/gallupinc/GallupSpaces/Production/Cms/EDUCMS/tz7n-7vqceaq86dprdnzag.jpg",
                    Birthday = DateTime.Parse("2000-04-06")
                },
                new Student
                {
                    Id = 3,
                    UniversityId = 10,
                    Name = "Minh",
                    Mobile = "0912345678",
                    Email = "nam@gmail.com",
                    Gender = 'M',
                    Grade = 7.8,
                    IsGraduated = true,
                    SId = "GCH12345",
                    Image = "https://img.freepik.com/free-photo/front-view-male-student-dark-t-shirt-yellow-backpack-holding-files-books-smiling-light-blue-wall_140725-46715.jpg?w=2000",
                    Birthday = DateTime.Parse("2000-04-06")
                }
            );
        }

    }
}
