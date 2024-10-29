using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Repositories.Interfaces
{
    public interface IUnitOfWorkDapper : IDisposable
    {
        ICourseRepository _courseRepository { get; }
        IModuleRepository _moduleRepository { get; }
        void Commit();
        void Dispose();
    }
}
