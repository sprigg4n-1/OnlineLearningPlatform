using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;


namespace Infrastructure.Repositories
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly TestDbContext testDbContext;
        private readonly IMemoryCache cache;

        public TestQuestionRepository(TestDbContext testDbContext, IMemoryCache cache)
        {
            this.testDbContext = testDbContext;
            this.cache = cache;
        }
        public async Task<TestQuestionEntity> CreateAsync(TestQuestionEntity testQuestion)
        {
            await testDbContext.AddAsync(testQuestion);
            await testDbContext.SaveChangesAsync();
            return testQuestion;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await testDbContext.TestsQuestion.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<TestQuestionEntity>> GetAllTestsAsync()
        {
            string cacheKey = "TestQuestions";

            if (!cache.TryGetValue(cacheKey, out List<TestQuestionEntity> questions))
            {
                Console.WriteLine("Get data `TestQs` from db, bc was not found in Redis");

                questions = await testDbContext.TestsQuestion.ToListAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSize(1)
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(5))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(2));

                cache.Set(cacheKey, questions, cacheOptions);
            } else
            {
                Console.WriteLine("Get data `TestQs` from RedisCache");
            }

            return questions;
        }

        public async Task<TestQuestionEntity> GetByIdAsync(int id)
        {
            return await testDbContext.TestsQuestion.Where(t => t.Id == id).FirstOrDefaultAsync();

        }

        public async Task<int> UpdateAsync(int id, TestQuestionEntity testQuestion)
        {
            return await testDbContext.TestsQuestion.Where(t => t.Id == id).ExecuteUpdateAsync(setters =>
            setters
                .SetProperty(t => t.QuestionText, testQuestion.QuestionText)
                .SetProperty(t => t.TestId, testQuestion.TestId)
            );
        }
    }
}
