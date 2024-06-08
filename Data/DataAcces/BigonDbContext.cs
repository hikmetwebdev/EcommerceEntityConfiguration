using BigonEcommerce.Models.Persistances.Configurations;
using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigonEcommerce.Data.DataAcces
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
        public DbSet<Blog> Blogs {get; set;}


        public override int SaveChanges()
        {
          var changes = this.ChangeTracker.Entries<IAuditibleEntity>();

            if (changes is not null)
            {
                foreach (var entry in changes.Where(ch=>ch.State==EntityState.Added || ch.State==EntityState.Modified ||
                ch.State==EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.CreatedBy = 1;
                            break;
                        case EntityState.Modified:
                            entry.Entity.ModifiedAt = DateTime.UtcNow;
                            entry.Entity.ModifiedBy = 1;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedAt = DateTime.UtcNow;
                            entry.Entity.DeletedBy = 1;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }


    }
}
