using Microsoft.EntityFrameworkCore;
using storehouse_Domain;

namespace storehouse_Data
{
    public class Storehouse_DBcontext: DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =(localdb)\\ProjectModels ; Initial Catalog = storehouseData");
        }
    }
}