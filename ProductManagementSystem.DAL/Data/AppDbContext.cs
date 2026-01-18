using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DOMAIN.Category;
using ProductManagementSystem.DOMAIN.Junctions;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                        .HasKey(p => p.ProductId);

            modelBuilder.Entity<CategoryEntity>()
                        .HasKey(c => c.CategoryId);

            modelBuilder.Entity<ProductEntity>()
                        .Property(p => p.Price)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasOne(pc => pc.Product)
                        .WithMany(p => p.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasOne(pc => pc.Category)
                        .WithMany(c => c.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
