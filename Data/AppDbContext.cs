using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Data
{
    public class AppDbContext : DbContext
    {
      

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsModel>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Products)
                .HasForeignKey("OrderId")
                .IsRequired(false); // Permite nulo

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<ProductsModel> Products { get; set; }

        public DbSet<StatusModel> Status { get; set; }
    }
}
