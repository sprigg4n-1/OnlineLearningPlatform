using Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetCachedDataAsync<T>(string key, Func<Task<T>> getDataFunc, MemoryCacheEntryOptions options)
        {
            if (!_memoryCache.TryGetValue(key, out T cacheData))
            {
                cacheData = await getDataFunc();
                _memoryCache.Set(key, cacheData, options);
            }

            return cacheData;
        }
    }

}
