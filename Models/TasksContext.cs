using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class TasksContext : DbContext
    {
        //Category (Dropdown containing options: Home, School, Work, Church)
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = ""},
                new Category { CategoryId = 2, CategoryName = "" },
                new Category { CategoryId = 3, CategoryName = "" },
                new Category { CategoryId = 4, CategoryName = "" }
            );
        }
    }
}
