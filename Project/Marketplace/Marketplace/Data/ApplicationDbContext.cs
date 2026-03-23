using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Электроника", Description = "Смартфоны, ноутбуки, планшеты" },
                new Category { Id = 2, Name = "Одежда", Description = "Мужская, женская, детская одежда" },
                new Category { Id = 3, Name = "Дом и сад", Description = "Мебель, декор, инструменты" },
                new Category { Id = 4, Name = "Спорт", Description = "Спортивный инвентарь, одежда" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Смартфон Galaxy S23",
                    Description = "Мощный смартфон с отличной камерой 50MP",
                    Price = 69999.99m,
                    Quantity = 50,
                    Category = "Электроника",
                    ImageUrl = "/images/s23.jpg",
                    Rating = 4.8,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Ноутбук MacBook Air",
                    Description = "Легкий и мощный ноутбук на чипе M2",
                    Price = 99999.99m,
                    Quantity = 25,
                    Category = "Электроника",
                    ImageUrl = "/images/macbook.jpg",
                    Rating = 4.9,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Беспроводные наушники",
                    Description = "Наушники с активным шумоподавлением",
                    Price = 12999.99m,
                    Quantity = 100,
                    Category = "Электроника",
                    ImageUrl = "/images/headphones.jpg",
                    Rating = 4.5,
                    IsAvailable = true
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}