using BigonEcommerce.Models.Entities;
using BigonEcommerce.Models.Persistances.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BigonEcommerce.Models.DataAcces
{
    public class BigondbContext : DbContext
    {
        public BigondbContext(DbContextOptions<BigondbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BigondbContext).Assembly);
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }



    }
}
