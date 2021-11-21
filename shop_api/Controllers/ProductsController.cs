using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Buy")]
        public bool Buy(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) 
                NotFound();
            var result = product.Buy();
            _context.SaveChanges();
            return result;
        }

        [HttpGet]
        public IEnumerable<Product> Index(string categorySlug)
        {
            var category = _context.Categories.Include("Products").Where(c => c.Slug == categorySlug).FirstOrDefault();
            if (category == null)
                NotFound();

            return category.Products;
        }

        [HttpGet("Get")]
        public Product Get(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
                NotFound();
            return product;
        }

        [HttpDelete]
        [Authorize]
        public bool Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                NotFound();
                return false;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        [HttpPut]
        [Authorize]
        public bool Create(string title, int price, int weight, int stock, int categoryId)
        {
            Product product = new Product
            {
                Title = title,
                CategoryId = categoryId,
                Stock = stock,
                Weight = weight,
                Price = price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return true;
        }
    }
}
