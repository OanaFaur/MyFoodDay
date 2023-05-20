using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFoodDay.Models;

namespace MyFoodDay.DataContext
{
    public class MyFoodContext : IdentityDbContext
    {
        public MyFoodContext()
        {

        }
        public MyFoodContext(DbContextOptions<MyFoodContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = MyFoodDay; Trusted_Connection = True; ");

        }

        public DbSet<Product> Products { get; set; }
    }
}
