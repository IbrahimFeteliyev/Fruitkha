using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class FruitkhaDbContext : IdentityDbContext<User>
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
        public DbSet<New> News { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }

    }
}
