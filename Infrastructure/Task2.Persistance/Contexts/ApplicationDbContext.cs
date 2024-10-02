using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Task2.Domain.Entities;

namespace Task2.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this.Database.BeginTransactionAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasIndex(c => c.Email)
               .IsUnique();


            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasMany(c => c.Addresses)
                      .WithOne(a => a.Customer)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasMany(c => c.Orders)
                      .WithOne(o => o.Customer)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasMany(o => o.OrderProducts)
                      .WithOne(op => op.Order)
                      .HasForeignKey(op => op.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Customer)
                      .WithMany(c => c.Addresses)
                      .HasForeignKey(a => a.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasMany(p => p.OrderProducts)
                      .WithOne(op => op.Product)
                      .HasForeignKey(op => op.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }

    }
}
