using System;
using System.Collections.Generic;

namespace shop_api
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
