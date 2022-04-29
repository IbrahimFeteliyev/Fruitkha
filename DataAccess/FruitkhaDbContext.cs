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
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<OurNew> OurNews { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
    }
}
