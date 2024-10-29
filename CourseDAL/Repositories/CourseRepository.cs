using CourseDAL.Entities;
using CourseDAL.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Repositories
{
    public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(sqlConnection, dbTransaction, "Course")
        {

        }


        public async Task<IEnumerable<Object>> GetCoursesWithModules()
        {
            string sql = @"SELECT 
                    m.Id AS ModuleId,
                    m.Title AS ModuleTitle,
                    c.Title AS CourseTitle,
                    c.Description AS CourseDescription
                FROM 
                    Module m
                JOIN 
                    Course c
                ON 
                    m.CourseId = c.Id;";

            var results = await _sqlConnection.QueryAsync(sql, transaction: _dbTransaction);

            var coursesWithModules = results.Select(row => new
            {
                ModuleId = row.ModuleId,
                ModuleTitle = row.ModuleTitle,
                CourseTitle = row.CourseTitle,
                CourseDescription = row.CourseDescription
            }).ToList();

            return results;
        }

        public async Task<IEnumerable<Object>> GetCoursesWithModuleCount()
        {
            string sql = @"SELECT 
                    c.Id AS CourseId,
                    c.Title AS CourseTitle,
                    COUNT(m.Id) AS ModuleCount
                FROM 
                    Course c
                LEFT JOIN 
                    Module m
                ON 
                    c.Id = m.CourseId
                GROUP BY 
                    c.Id, c.Title;";

            var results = await _sqlConnection.QueryAsync(sql, transaction: _dbTransaction);

            var coursesWithModuleCount = results.Select(row => new
            {
                CourseId = row.CourseId,
                CourseTitle = row.CourseTitle,
                ModuleCount = row.ModuleCount
            }).ToList();

            return coursesWithModuleCount;
        }
    }
}
