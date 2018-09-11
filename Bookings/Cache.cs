using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Bookings
{
    public class Cache
    {

        private const string CacheKey = "products";
        ObjectCache cache = MemoryCache.Default;

        public void SaveCache(List<ProductModel> products)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(2);
            cache.Add(CacheKey, products, cacheItemPolicy);
        }

        public bool hasData()
        {
            if (cache.Contains(CacheKey))
                return true;
            return false;
        }

        public List<ProductModel> GetCache()
        {
            return (List<ProductModel>)cache.Get(CacheKey);
        }
    }
}