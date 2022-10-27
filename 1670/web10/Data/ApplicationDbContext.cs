using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using web10.Models;

namespace web10.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //khai báo DbSet để biến model thành bảng (table)
        //và để sử dụng (gọi) trong Controller 
        public DbSet<Product> Product { get; set; } 
    }
}
