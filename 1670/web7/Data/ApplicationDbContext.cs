using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using web7.Models;

namespace web7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //tạo table từ class Model
        //Note: tên của table có thể giống hoặc khác với tên Model
        public DbSet<Motorbike> Motorbike { get; set; }
    }
}
