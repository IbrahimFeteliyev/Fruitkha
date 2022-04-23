using Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class FruitkhaDbContext : DbContext
    {

        public FruitkhaDbContext(DbContextOptions<FruitkhaDbContext> options)
          : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
