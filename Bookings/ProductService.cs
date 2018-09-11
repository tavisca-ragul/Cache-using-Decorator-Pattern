using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings
{
    abstract public class ProductService : IRepository
    {
        protected IRepository repository;

        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }

        public virtual List<ProductModel> GetProducts(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}