using EcommerceStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStore.DbContexts;

public class EcommerceStoreContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;

    public EcommerceStoreContext(DbContextOptions<EcommerceStoreContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product("Produto A")
            {
                Id = 1,
                Description = "Descrição 1",
                Price = 100
            },
            new Product("Produto B")
            {
                Id = 2,
                Description = "Descrição 2",
                Price = 100
            },
            new Product("Produto C")
            {
                Id = 3,
                Description = "Descrição 3",
                Price = 100
            }
        );

        modelBuilder.Entity<Image>().HasData(
            new Image("image_a.png")
            {
                Id = 1,
                ProductId = 1
            },
            new Image("image_b.png")
            {
                Id = 2,
                ProductId = 2
            },
            new Image("image_c.png")
            {
                Id = 3,
                ProductId = 3
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category("Casa")
            {
                Id = 1,
                ProductId = 1
            },
            new Category("Moda")
            {
                Id = 2,
                ProductId = 2
            },
            new Category("Eletrodomésticos")
            {
                Id = 3,
                ProductId = 3
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}