using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ECommerce.Data.Entities;

namespace ECommerce.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Title> Titles { get; set; }
        public DbSet<Entities.OutgoingEmail> OutgoingEmails { get; set; }
        public DbSet<Entities.Menu> Menus { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Title>().HasData(new Entities.Title() {
                Id = (int)Enum.UserTitle.Customer,
                Name = "Müşteri",
                Active = true,
                CreateDate = DateTime.UtcNow,
                Deleted = false                
            });
            modelBuilder.Entity<Entities.Title>().HasData(new Entities.Title()
            {
                Id = (int)Enum.UserTitle.Administrator,
                Name = "Yönetici",
                Active = true,
                CreateDate = DateTime.UtcNow,
                Deleted = false
            });
            modelBuilder.Entity<Entities.User>().HasData(new Entities.User() {
                Id = 1,
                Active = true,
                Admin = true,
                CreateDate = DateTime.UtcNow,
                Deleted = false,
                Email = "admin@admin.com",
                Name = "Admin",
                Surname = "Admin",
                Password = Helper.CryptoHelper.Sha1("12345678"),
                TitleId = (int)Enum.UserTitle.Administrator,
                EmailVerified = true
            });
            modelBuilder.Entity<Menu>().HasData(new List<Menu>()
            {
                new Menu()
                {
                    Id = 1,
                    Name = "Header"
                },
                new Menu()
                {
                    Id = 2,
                    Name = "Footer"
                }
            });
        }
    }
}