using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_api
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
                //context.Categories.RemoveRange(context.Categories);
                //context.Products.RemoveRange(context.Products);
                //context.SaveChanges();
            }
            var categories = new Category[] {
                new Category
                {
                    Id = 1,
                    Title = "Игровые",
                    Slug = "gamers"
                },
                new Category
                {
                    Id = 2,
                    Title = "Офисные",
                    Slug = "office"
                },
                new Category
                {
                    Id = 3,
                    Title = "Для дизайна",
                    Slug = "design"
                }
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[] {
                new Product
                {
                    Title = "Монитор GamerX21",
                    CategoryId = 1,
                    Stock = 0,
                    Weight = 1000,
                    Price = 33000
                },
                new Product
                {
                    Title = "Монитор FreeRepublic",
                    CategoryId = 1,
                    Stock = 20,
                    Weight = 1500,
                    Price = 55000
                },
                new Product
                {
                    Title = "Монитор KDA",
                    CategoryId = 1,
                    Stock = 25,
                    Weight = 2000,
                    Price = 12770
                },
                new Product
                {
                    Title = "Монитор Olimp",
                    CategoryId = 1,
                    Stock = 5,
                    Weight = 1400,
                    Price = 52000
                },
                new Product
                {
                    Title = "Монитор HG-215",
                    CategoryId = 2,
                    Stock = 41,
                    Weight = 2400,
                    Price = 12000
                },
                new Product
                {
                    Title = "Монитор Work-099",
                    CategoryId = 2,
                    Stock = 1,
                    Weight = 1400,
                    Price = 14000
                },
                new Product
                {
                    Title = "Монитор Xt2017",
                    CategoryId = 2,
                    Stock = 11,
                    Weight = 1950,
                    Price = 19300
                },
                new Product
                {
                    Title = "Монитор UltraGraph",
                    CategoryId = 3,
                    Stock = 13,
                    Weight = 1250,
                    Price = 29300
                },
                new Product
                {
                    Title = "Монитор SharpView",
                    CategoryId = 3,
                    Stock = 333,
                    Weight = 4350,
                    Price = 140300
                },
                new Product
                {
                    Title = "Монитор GM-graphic",
                    CategoryId = 3,
                    Stock = 3,
                    Weight = 3350,
                    Price = 81300
                }
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
                context.SaveChanges();
            }
            

        }

    }

}
