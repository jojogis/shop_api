using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shop_api
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
