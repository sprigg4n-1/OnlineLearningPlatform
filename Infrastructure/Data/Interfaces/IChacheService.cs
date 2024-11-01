using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Data.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetCachedDataAsync<T>(string key, Func<Task<T>> getDataFunc, MemoryCacheEntryOptions options);
    }

}
