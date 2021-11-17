using Microsoft.EntityFrameworkCore;
using SaveFood.Models;

namespace SaveFood.Persistence
{
    public class SaveFoodContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SaveFoodContext(DbContextOptions options) : base(options)
        {

        }
    }
}
