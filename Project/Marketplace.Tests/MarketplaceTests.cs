using Marketplace.Data;
using Marketplace.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Marketplace.Tests
{
    public class MarketplaceTests
    {
        private ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task Product_CanBeAddedToDatabase()
        {
            // Arrange
            var context = GetContext();
            var category = new Category { Name = "Скины" };
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            var product = new Product
            {
                Name = "Invoker Arcana",
                Description = "Легендарный скин",
                Price = 1299,
                Stock = 10,
                CategoryId = category.Id
            };

            // Act
            context.Products.Add(product);
            await context.SaveChangesAsync();

            // Assert
            var saved = await context.Products.FirstOrDefaultAsync(p => p.Name == "Invoker Arcana");
            Assert.NotNull(saved);
            Assert.Equal(1299, saved.Price);
        }

        [Fact]
        public async Task Category_CanBeAddedToDatabase()
        {
            // Arrange
            var context = GetContext();
            var category = new Category { Name = "Герои" };

            // Act
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            // Assert
            var saved = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Герои");
            Assert.NotNull(saved);
            Assert.Equal("Герои", saved.Name);
        }
    }
}
