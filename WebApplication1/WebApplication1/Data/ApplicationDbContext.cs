using Microsoft.AspNetCore.Identity;
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
        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Note: add dữ liệu cho bảng chứa PK trước
            //rồi add dữ liệu cho bảng chứa FK sau 
            PopulateBook(builder);
            PopulateCategory(builder);
            //add dữ liệu cho bảng User
            SeedUser(builder);

            //add dữ liệu cho bảng Role
            SeedRole(builder);

            //add dữ liệu cho bảng UserRole
            SeedUserRole(builder);
        }

        private void PopulateCategory(ModelBuilder builder)
        {
            var Horror = new Category
            {
                Id = 1,
                Name = "Horror"        
            };
            var Hai = new Category
            {
                Id = 2,
                Name = "Trinh Thám"
            };
            var Ba = new Category
            {
                Id = 3,
                Name = "Thiếu Nhi"
            };
            var Bon  = new Category
            {
                Id = 4,
                Name = "Khoa Học Viễn Tưởng"
            };
             
            
            builder.Entity<Category>().HasData(Horror,Hai,Ba,Bon);
        }

        private void PopulateBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Nữ Hoàng Tuyết",
                    Author = "Smith",
                    Price = 69999,
                    Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
                },


            new Book
            {
                Id = 2,
                CategoryId = 1,
                Name = "Hoàng Tử Gấu",
                Author = "Thomas",
                Price = 69999,
                Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
            },

            new Book
            {
                Id = 3,
                CategoryId = 3,
                Name = "Thợ Săn Bóng Đêm",
                Author = "Thomson",
                Price = 69999,
                Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
            },

            new Book
            {
                Id = 4,
                CategoryId = 2,
                Name = "Vua Sư Tử",
                Author = "Alpha",
                Price = 69999,
                Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
            },

            new Book
            {
                Id = 5,
                CategoryId = 3,
                Name = "Dải Ngân Hà",
                Author = "Denta",
                Price = 69999,
                Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
            },

            new Book
            {
                Id = 6,
                CategoryId = 1,
                Name = "Huyền Thoại Võ Thuật",
                Author = "Catary",
                Price = 69999,
                Image = "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0"
            }
            ) ;
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "A"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "B"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "C"
                }
             );
        }
        private void SeedRole(ModelBuilder builder)
        {
            //1. tạo các role cho hệ thống
            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            var customer = new IdentityRole
            {
                Id = "B",
                Name = "Customer",
                NormalizedName = "Customer"
            };
            var store_owner = new IdentityRole
            {
                Id = "C",
                Name = "Storner",
                NormalizedName = "Stornner"
            };
            //2. add role vào trong DB
            builder.Entity<IdentityRole>().HasData(admin, customer,store_owner);
        }


        

       
        private void SeedUser(ModelBuilder builder)
        {
            //1. tạo tài khoản ban đầu để add vào DB
            var admin = new IdentityUser
            {
                Id = "1",
                UserName = "admin@fpt.com",
                Email = "admin@fpt.com",
                NormalizedUserName = "admin@fpt.com",
                EmailConfirmed = true
            };

            var customer = new IdentityUser
            {
                Id = "2",
                UserName = "customer@fpt.com",
                Email = "customer@fpt.com",
                NormalizedUserName = "customer@fpt.com",
                EmailConfirmed = true
            };
            var storner = new IdentityUser
            {
                Id = "3",
                UserName = "storner@fpt.com",
                Email = "storner@fpt.com",
                NormalizedUserName = "storner@fpt.com",
                EmailConfirmed = true
            };

            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<IdentityUser>();

            //3. thiết lập và mã hóa mật khẩu từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "a123@A");
            customer.PasswordHash = hasher.HashPassword(customer, "a123@A");
            storner.PasswordHash = hasher.HashPassword(storner, "a123@A");

            //4. add tài khoản vào db
            builder.Entity<IdentityUser>().HasData(admin, customer,storner);
        
        }
    }
}
