using eb4395u202117303.API.Operations.Domain.Model.Aggregates;
using eb4395u202117303.API.Operations.Domain.Model.Entities;
using eb4395u202117303.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions; 
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Operations.Infrastructure.Persistence
{
    public class OperationsDbContext : DbContext
    {
        public OperationsDbContext(DbContextOptions<OperationsDbContext> options) : base(options) { }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Assignment>().HasKey(p => p.Id);
            builder.Entity<Assignment>().HasIndex(p => p.StudentId).IsUnique();
            
            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Emma", LastName = "Smith", DistrictId = 1, ParentId = 101 },
                // ... resto de students ...
                new Student { Id = 10, FirstName = "Lucas", LastName = "Jackson", DistrictId = 3, ParentId = 105 }
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}