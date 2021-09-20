using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_api
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public float Weight { get; set; }

        public int Stock { get; set; }

        public virtual Category Category{ get; set; }

        public bool Buy() {
            if (Stock > 0)
            {
                Stock--;
                return true;
            }
            else return false;
        }
    }
}
