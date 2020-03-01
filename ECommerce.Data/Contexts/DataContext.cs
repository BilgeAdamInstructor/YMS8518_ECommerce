using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Title>().HasData(new Entities.Title() {
                Id = (int)Enums.UserTitle.Customer,
                Name = "Müşteri",
                Active = true,
                CreateDate = DateTime.UtcNow,
                Deleted = false                
            });
            modelBuilder.Entity<Entities.Title>().HasData(new Entities.Title()
            {
                Id = (int)Enums.UserTitle.Administrator,
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
                TitleId = (int)Enums.UserTitle.Administrator
            });
        }
    }
}