using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_api
{
    public static class BD
    {
        public static IEnumerable<Category> Categories()
        {
            Category[] categories = {
                 new Category
                {
                    Title = "Игровые",
                    Id = 0,
                    Slug = "gamers"
                },
                new Category
                {
                    Title = "Офисные",
                    Id = 1,
                    Slug = "office"
                },
                new Category
                {
                    Title = "Для дизайна",
                    Id = 2,
                    Slug = "design"
                }
            };
            return categories;
        }

        public static IEnumerable<Product> Products()
        {
            Product[] products = {
                new Product
                {
                    Title = "Монитор GamerX21",
                    Id = 0,
                    Category = Categories().ElementAt(0),
                    Stock = 0,
                    Weight = 1000,
                    Price = 33000
                },
                new Product
                {
                    Title = "Монитор FreeRepublic",
                    Id = 1,
                    Category = Categories().ElementAt(0),
                    Stock = 20,
                    Weight = 1500,
                    Price = 55000
                },
                new Product
                {
                    Title = "Монитор KDA",
                    Id = 2,
                    Category = Categories().ElementAt(0),
                    Stock = 25,
                    Weight = 2000,
                    Price = 12770
                },
                new Product
                {
                    Title = "Монитор Olimp",
                    Id = 3,
                    Category = Categories().ElementAt(0),
                    Stock = 5,
                    Weight = 1400,
                    Price = 52000
                },
                new Product
                {
                    Title = "Монитор HG-215",
                    Id = 4,
                    Category = Categories().ElementAt(1),
                    Stock = 41,
                    Weight = 2400,
                    Price = 12000
                },
                new Product
                {
                    Title = "Монитор Work-099",
                    Id = 5,
                    Category = Categories().ElementAt(1),
                    Stock = 1,
                    Weight = 1400,
                    Price = 14000
                },
                new Product
                {
                    Title = "Монитор Xt2017",
                    Id = 6,
                    Category = Categories().ElementAt(1),
                    Stock = 11,
                    Weight = 1950,
                    Price = 19300
                },
                new Product
                {
                    Title = "Монитор UltraGraph",
                    Id = 7,
                    Category = Categories().ElementAt(2),
                    Stock = 13,
                    Weight = 1250,
                    Price = 29300
                },
                new Product
                {
                    Title = "Монитор SharpView",
                    Id = 8,
                    Category = Categories().ElementAt(2),
                    Stock = 333,
                    Weight = 4350,
                    Price = 140300
                },
                new Product
                {
                    Title = "Монитор GM-graphic",
                    Id = 9,
                    Category = Categories().ElementAt(2),
                    Stock = 3,
                    Weight = 3350,
                    Price = 81300
                },
            };
            return products;

        }

    }

}
