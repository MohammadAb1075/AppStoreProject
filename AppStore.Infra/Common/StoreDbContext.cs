using AppStore.Domain.Categories;
using AppStore.Domain.Orders;
using AppStore.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Infra.Data.Sql.Common
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Mobile"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Tablet"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Laptop"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "PC"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Mobile"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData
                (
                    new Product
                    {
                        Id = 1,
                        CategoryId = 1,
                        Name = "Apple iPhon 13",
                        Description = "Description Apple iPhon 13",
                        Price = 3000000
                    },
                    new Product
                    {
                        Id = 2,
                        CategoryId = 1,
                        Name = "Samsung A52 5G",
                        Description = "Description Samsung A52 5G",
                        Price = 3000000
                    },
                    new Product
                    {
                        Id = 3,
                        CategoryId = 1,
                        Name = "Samsung Galaxy Note 22",
                        Description = "Description Galaxy Note 22",
                        Price = 20000000
                    },
                    new Product
                    {
                        Id = 4,
                        CategoryId = 3,
                        Name = "Lenovo ideapad Gaming",
                        Description = "Description Lenovo ideapad Gaming",
                        Price = 45000000
                    },
                    new Product
                    {
                        Id = 5,
                        CategoryId = 3,
                        Name = "Asus ZenBook",
                        Description = "Description Asus ZenBook",
                        Price = 50000000
                    },
                    new Product
                    {
                        Id = 6,
                        CategoryId = 3,
                        Name = "MSI",
                        Description = "MSI",
                        Price = 60000000
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
