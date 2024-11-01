using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITestQuestionRepository
    {
        Task<List<TestQuestionEntity>> GetAllTestsAsync();
        Task<TestQuestionEntity> GetByIdAsync(int id);
        Task<TestQuestionEntity> CreateAsync(TestQuestionEntity testQuestion);
        Task<int> UpdateAsync(int id, TestQuestionEntity testQuestion);
        Task<int> DeleteAsync(int id);
    }
}
