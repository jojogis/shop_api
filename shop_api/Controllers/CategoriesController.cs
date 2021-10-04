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
    public class CategoriesController : ControllerBase {

        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Index()
        {
            return _context.Categories;
        }

        [HttpGet("Get")]
        public Category Get(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
                NotFound();
            return category;
        }

        [HttpDelete]
        public bool Delete(int id, bool deleteNotEmpty)
        {
            Category category = _context.Categories.Include("Products").FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                NotFound();
                return false;
            }

            if (category.Products.Count != 0 && !deleteNotEmpty) return false;

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }

        [HttpPut]
        public bool Create(string name, string slug)
        {
            Category category = new Category
            {
                Title = name,
                Slug = slug
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return true;
        }

    }
}
