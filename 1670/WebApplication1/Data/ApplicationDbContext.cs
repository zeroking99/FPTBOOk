using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<University> Universities{ get;set; }


        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            //add dữ liệu cho bẳng chứa pK trc (university)
            //add dữ liệu cho bảng chứa fk sau(student)
            //add dữ liệu khởi tạo cho bảng university
            PopulateUniversity(builder);
            //add dữ liệ khởi tạo (initial daata) cho bảng student
            SeedStudent(builder);
          
        }

        private void PopulateUniversity(ModelBuilder builder)
        {
            var greenwich = new University { Id = 10, Name = "Greenwich", Address = "cẦu giấy",
                Logo = "https://znews-photo.zingcdn.me/w660/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg" };
            var harvard = new University
            {
                Id = 11,
                Name = "Greenwich",
                Address = "Duy Tân",
                Logo = "https://znews-photo.zingcdn.me/w660/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg"
            };
            builder.Entity<University>().HasData(greenwich, harvard);
               
        }

        private void SeedStudent(ModelBuilder builder)
        {
            // add dữ liệu tự động vào DB bằng code
            builder.Entity<Student>().HasData(
                //bắt buộc phải nhập giá trị cho cột Id
                //Những thuộc tính set là "required" ở trong file thì nhập

                new Student
                {
                    Id = 10,
                    unId = 11,
                    Name = "Nguyen van B",
                    Birthday = DateTime.Parse("2000-3-1"),
                    Email = "nana@gmail.com",
                    Gender = 'F',
                    Grade = 4.9,
                    IsGraduated = true,
                    Mobile = "0910038023",
                    SId = "GCH12345",
                    Image = "https://znews-photo.zingcdn.me/w660/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg"
                },
                 new Student
                 {
                     Id = 11,
                     unId = 10,
                     Name = "Nguyen van B",
                     Birthday = DateTime.Parse("2000-3-1"),
                     Email = "nana@gmail.com",
                     Gender = 'F',
                     Grade = 9.1,
                     IsGraduated = true,
                     Mobile = "0910038023",
                     SId = "GCH12345",
                     Image = "https://znews-photo.zingcdn.me/w660/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg"
                 }
                ) ;
        }
    }
}
