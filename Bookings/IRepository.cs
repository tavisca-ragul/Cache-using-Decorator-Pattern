using System.Collections.Generic;

namespace Bookings
{
    public interface IRepository
    {
        List<ProductModel> GetProducts(IProduct product);
    }
}