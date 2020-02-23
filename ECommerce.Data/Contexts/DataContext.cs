using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Entities.User> Users { get; set; }
    }
}