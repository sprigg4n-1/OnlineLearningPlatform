using CourseDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<int> AddModuleAsync(string title, string description, TimeSpan duration, int courseId);
        Task<List<ModuleEntity>> GetAllModulesAsync();
        Task<ModuleEntity> GetModuleByIdAsync(int id);
        Task UpdateModuleAsync(int id, string title, string description, TimeSpan duration, int courseId);
        Task DeleteModuleAsync(int id);
    }
}
