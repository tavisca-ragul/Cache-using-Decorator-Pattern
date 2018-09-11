using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    class ProductServiceCache : ProductService
    {
        private Cache cache;

        public ProductServiceCache(IRepository repository, Cache cache) : base (repository)
        {
            this.cache = cache;
        }

        public override List<ProductModel> GetProducts(IProduct product)
        {
            if (cache.hasData())
            {
                Console.WriteLine("From Cache Memory:");
                return cache.GetCache();
            }
            else
            {
                Console.WriteLine("Loading from database:");
                List<ProductModel> products = repository.GetProducts(product);
                cache.SaveCache(products);
                return products;
            }
        }
    }
}