using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class TasksContext : DbContext
    {
        //Constructor
        public TasksContext(DbContextOptions<TasksContext> options) : base (options)
        {
            //leave blank
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskEntry> Tasks { get; set; }

        

        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName = "Home"},
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }

                );

            mb.Entity<TaskEntry>().HasData(

                new TaskEntry
                {
                    TaskId = 1,
                    Task = "Get an A in IS 413",
                    DueDate = "04/23/2022",
                    CategoryId = 2,
                    Quadrant = 2,
                    Completed = false
                },

                new TaskEntry
                {
                    TaskId = 2,
                    Task = "Get flowers for Professor Hilton",
                    DueDate = "02/14/2022",
                    CategoryId = 2,
                    Quadrant = 2,
                    Completed = false
                }
                );
        }
    }
}
