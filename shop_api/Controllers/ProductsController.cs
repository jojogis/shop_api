using Microsoft.AspNetCore.Mvc;
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

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Buy")]
        public bool Buy(string id)
        {
            Product product = BD.Products().Where(product => product.Id == int.Parse(id)).First();
            return product.Buy();
        }

        [HttpGet]
        public IEnumerable<Product> Get(string category)
        {
            return BD.Products().Where(product => product.Category.Slug == category);
        }
    }
}
