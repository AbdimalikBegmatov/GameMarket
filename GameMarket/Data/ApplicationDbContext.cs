using GameMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace GameMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Raiting> Raitings { get; set; }
        public DbSet<Article> Articles { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasIndex(p => p.Name).IsUnique();
                builder.HasIndex(p => p.RetailPrice);
                builder.HasIndex(p => p.PurchasePrice);
                builder.HasIndex(p => p.DeveloperCompany);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasIndex(p => p.AddedTime);
                builder.HasIndex(p => p.ShippedTime);
            });
        }
    }
}
