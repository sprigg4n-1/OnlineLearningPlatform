using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITestRepository
    {
        Task<List<TestEntity>> GetAllTestsAsync();
        Task<TestEntity> GetByIdAsync(int id);
        Task<TestEntity> CreateAsync(TestEntity test);
        Task<int> UpdateAsync(int id, TestEntity test);
        Task<int> DeleteAsync(int id);
    }
}
