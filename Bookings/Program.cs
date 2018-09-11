using System;
using System.Collections.Generic;

namespace Bookings
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct product = ProductFactory.GetProduct("CarProduct");
            IRepository repository = RepositoryFactory.GetRepository("SQLDatabase");
            ProductService productSerivice = new ProductServiceCache(repository, new Cache());
            List<ProductModel> products = productSerivice.GetProducts(product);
            foreach(ProductModel list in products)
            {
                Console.WriteLine(string.Format("ID: {0}, Name: {1}, Price: {2}", list.id, list.name, list.price));
            }
            products = productSerivice.GetProducts(product);
            foreach (ProductModel list in products)
            {
                Console.WriteLine(string.Format("ID: {0}, Name: {1}, Price: {2}", list.id, list.name, list.price));
            }
            Console.ReadLine();
        }
    }
}