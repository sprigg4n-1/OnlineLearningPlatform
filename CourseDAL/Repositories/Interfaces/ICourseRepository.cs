using CourseDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<CourseEntity>
    {
        Task<IEnumerable<Object>> GetCoursesWithModules();
        Task<IEnumerable<Object>> GetCoursesWithModuleCount();

    }
}
