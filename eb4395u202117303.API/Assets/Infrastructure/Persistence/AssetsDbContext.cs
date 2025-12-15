using eb4395u202117303.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using eb4395u202117303.API.Assets.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Assets.Infrastructure.Persistence
{
    public class AssetsDbContext : DbContext
    {
        public AssetsDbContext(DbContextOptions<AssetsDbContext> options) : base(options) { }
        public DbSet<Bus> Buses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            builder.Entity<Bus>().HasKey(p => p.Id);
            builder.Entity<Bus>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bus>().Property(p => p.VehiclePlate).IsRequired().HasMaxLength(10);
            builder.Entity<Bus>().HasIndex(p => p.VehiclePlate).IsUnique();


            builder.UseSnakeCaseNamingConvention();
        }
    }
}