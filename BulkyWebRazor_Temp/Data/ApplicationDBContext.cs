﻿using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { ID = 3, Name = "History", DisplayOrder = 3 }
                );
            //base.OnModelCreating(modelBuilder); 
        }
    }
}
