using Marketplace.Data;
using Marketplace.Model;
using Microsoft.EntityFrameworkCore;

namespace Marketplace
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (await context.Categories.AnyAsync()) return;

            var categories = new List<Category>
            {
                new Category { Name = "Герои" },
                new Category { Name = "Скины" },
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var heroes = categories[0];
            var skins = categories[1];

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Invoker — Demon Witch",
                    Description = "Легендарный скин для Инвокера. Превращает героя в могущественного демона-колдуна.",
                    Price = 1299,
                    Stock = 50,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/invoker_full.png"
                },
                new Product
                {
                    Name = "Anti-Mage — Шлем Ярости",
                    Description = "Эксклюзивный шлем для Анти-мага. Редкий предмет из коллекции Battle Pass 2023.",
                    Price = 899,
                    Stock = 30,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/antimage_full.png"
                },
                new Product
                {
                    Name = "Crystal Maiden — Arcana",
                    Description = "Арканный образ для Crystal Maiden. Включает кастомные эффекты способностей и анимации.",
                    Price = 2499,
                    Stock = 15,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/crystal_maiden_full.png"
                },
                new Product
                {
                    Name = "Pudge — Feast of Abscession",
                    Description = "Легендарный набор для Пуджа с кастомными звуками и эффектами крюка.",
                    Price = 1799,
                    Stock = 25,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/pudge_full.png"
                },
                new Product
                {
                    Name = "Juggernaut — Bladeform Legacy",
                    Description = "Арканный образ Джаггернаута. Один из самых популярных скинов в игре.",
                    Price = 2999,
                    Stock = 10,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/juggernaut_full.png"
                },
                new Product
                {
                    Name = "Phantom Assassin — Arcana",
                    Description = "Арканный образ для PA. Включает кастомный экран смерти и эффекты крита.",
                    Price = 2499,
                    Stock = 20,
                    CategoryId = skins.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/phantom_assassin_full.png"
                },
                new Product
                {
                    Name = "Invoker",
                    Description = "Герой Инвокер — один из сложнейших и популярнейших героев Dota 2. Маг с 10 заклинаниями.",
                    Price = 0,
                    Stock = 999,
                    CategoryId = heroes.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/invoker_full.png"
                },
                new Product
                {
                    Name = "Anti-Mage",
                    Description = "Быстрый керри-герой, специализирующийся на уничтожении маны врагов и быстром фарме.",
                    Price = 0,
                    Stock = 999,
                    CategoryId = heroes.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/antimage_full.png"
                },
                new Product
                {
                    Name = "Pudge",
                    Description = "Культовый герой-саппорт с крюком. Самый популярный герой в Dota 2 по количеству игр.",
                    Price = 0,
                    Stock = 999,
                    CategoryId = heroes.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/pudge_full.png"
                },
                new Product
                {
                    Name = "Crystal Maiden",
                    Description = "Поддерживающий герой с мощной ультой. Отличный выбор для командной игры.",
                    Price = 0,
                    Stock = 999,
                    CategoryId = heroes.Id,
                    ImageUrl = "https://cdn.dota2.com/apps/dota2/images/heroes/crystal_maiden_full.png"
                },
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
