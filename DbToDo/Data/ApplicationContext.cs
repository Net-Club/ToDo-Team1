using ToDo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User { UserId=1, Name="Vladyslav"},
                new User { UserId=2, Name="Nazar"},
                new User { UserId=3, Name="Volodymyr"},
            });
        }
    }
}
