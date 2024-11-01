using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly TestDbContext testDbContext;
        private readonly IDistributedCache distributedCache;

        public TestRepository(TestDbContext testDbContext, IDistributedCache distributedCache)
        {
            this.testDbContext = testDbContext;
            this.distributedCache = distributedCache;
        }
        public async Task<TestEntity> CreateAsync(TestEntity test)
        {
            await testDbContext.AddAsync(test);
            await testDbContext.SaveChangesAsync();
            return test;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await testDbContext.Tests.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<TestEntity>> GetAllTestsAsync()
        {
            string cacheKey = "TestQuestions";

            var cachedData = await distributedCache.GetStringAsync(cacheKey);

            if (cachedData != null)
            {
                Console.WriteLine("Get data `Tests` from RedisCache");
                return JsonSerializer.Deserialize<List<TestEntity>>(cachedData);
            }

            Console.WriteLine("Get data `Tests` from db, bc was not found in Redis");

            var tests = await testDbContext.Tests.ToListAsync();

            var cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));

            var serializedData = JsonSerializer.Serialize(tests);

            await distributedCache.SetStringAsync(cacheKey, serializedData, cacheOptions);

            return tests;
        }

        public async Task<TestEntity> GetByIdAsync(int id)
        {
            return await testDbContext.Tests.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(int id, TestEntity test)
        {
            return await testDbContext.Tests.Where(t => t.Id == id).ExecuteUpdateAsync(setters => 
                setters
                    .SetProperty(t => t.Title, test.Title)
                    .SetProperty(t => t.Description, test.Description)
                    .SetProperty(t => t.TimeLimit, test.TimeLimit)
                    .SetProperty(t => t.CourseId, test.CourseId)
            );
        }
    }
}
