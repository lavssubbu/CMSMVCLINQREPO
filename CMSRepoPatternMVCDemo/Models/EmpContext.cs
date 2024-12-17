using Microsoft.EntityFrameworkCore;

namespace CMSRepoPatternMVCDemo.Models
{
    public class EmpContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmpContext(DbContextOptions<EmpContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Employee-Department relationship using Fluent API
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
