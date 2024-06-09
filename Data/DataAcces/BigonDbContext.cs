using BigonEcommerce.Models.Persistances.Configurations;
using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using Infrastructure.Services.Classes;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BigonEcommerce.Data.DataAcces
{
    public class BigondbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IUserServices _userService;
        public BigondbContext(DbContextOptions<BigondbContext> options, IDateTimeService dateTimeService, IUserServices userService) : base(options)
        {
            _dateTimeService = dateTimeService;
            _userService = userService;
        }


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
        public DbSet<Blog> Blogs { get; set; }


        public override int SaveChanges()
        {
            var changes = this.ChangeTracker.Entries<IAuditibleEntity>();

            if (changes is not null)
            {
                foreach (var entry in changes.Where(ch => ch.State == EntityState.Added || ch.State == EntityState.Modified ||
                ch.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.CreatedBy = _userService.GetPrincipialId();

                            break;
                        case EntityState.Modified:
                            entry.Entity.ModifiedAt = entry.Entity.DeletedAt = _dateTimeService.ExecutingTime;
                            entry.Entity.ModifiedBy = _userService.GetPrincipialId();
                            entry.Property(x => x.CreatedAt).IsModified = false;
                            entry.Property(x => x.CreatedBy).IsModified = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedAt = _dateTimeService.ExecutingTime;
                            entry.Entity.DeletedBy = _userService.GetPrincipialId();

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
