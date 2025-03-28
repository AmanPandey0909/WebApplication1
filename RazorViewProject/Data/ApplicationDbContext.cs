using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using RazorViewProject.model;


namespace RazorViewProject.Data
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            public DbSet<Category> Category{ get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Aman", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Ankit", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Ankur", DisplayOrder = 3 }
                    );
            }
        }
    }


