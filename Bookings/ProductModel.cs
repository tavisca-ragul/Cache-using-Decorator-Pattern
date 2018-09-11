using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    public class ProductModel
    {
        public ProductModel(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int id { get; }
        public string name { get; }
        public double price { get; }
    }
}