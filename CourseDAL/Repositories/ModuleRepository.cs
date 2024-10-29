using CourseDAL.Entities;
using CourseDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly SqlConnection _sqlConnection;
        public ModuleRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<List<ModuleEntity>> GetAllModulesAsync()
        {
            var modules = new List<ModuleEntity>();

            string query = "SELECT * FROM Module";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                await _sqlConnection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        modules.Add(new ModuleEntity
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Duration = TimeSpan.FromMinutes(reader.GetInt32(reader.GetOrdinal("Duration"))),
                            CourseId = reader.GetInt32(reader.GetOrdinal("CourseId"))
                        });
                    }
                }
            }

            return modules;
        }
        public async Task<ModuleEntity> GetModuleByIdAsync(int id)
        {
            ModuleEntity module = null;

            string query = "SELECT * FROM Module WHERE Id = @Id";
            using (var command = new SqlCommand(query, _sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await _sqlConnection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        module = new ModuleEntity
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Duration = TimeSpan.FromMinutes(reader.GetInt32(reader.GetOrdinal("Duration"))),
                            CourseId = reader.GetInt32(reader.GetOrdinal("CourseId"))
                        };
                    }
                }
                await _sqlConnection.CloseAsync();
            }

            return module;
        }


        public async Task<int> AddModuleAsync(string title, string description, TimeSpan duration, int courseId)
        {
            string query = "INSERT INTO Module (Title, Description, Duration, CourseId) OUTPUT INSERTED.Id VALUES (@Title, @Description, @Duration, @CourseId)";


            using (var command = new SqlCommand(query, _sqlConnection))
            {
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@Duration", duration.TotalMinutes);

                try
                {
                    await _sqlConnection.OpenAsync();

                    var insertedId = (int)await command.ExecuteScalarAsync();

                    return insertedId;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    await _sqlConnection.CloseAsync();
                }
            }
        }


        public async Task UpdateModuleAsync(int id, string title, string description, TimeSpan duration, int courseId)
        {
            string query = "UPDATE Module SET Title = @Title, Description = @Description, Duration = @Duration, CourseId = @CourseId WHERE Id = @Id";


            using (var command = new SqlCommand(query, _sqlConnection))
            {
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@Duration", duration.TotalMinutes);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    await _sqlConnection.OpenAsync();

                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows == 0)
                    {
                        throw new Exception("No rows were updated. The module may not exist.");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    await _sqlConnection.CloseAsync();
                }
            }
        }

        public async Task DeleteModuleAsync(int id)
        {
            string query = "DELETE FROM Module WHERE Id = @Id";

            using (var command = new SqlCommand(query, _sqlConnection))
            {
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    await _sqlConnection.OpenAsync();

                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows == 0)
                    {
                        throw new Exception("No rows were deleted. The module may not exist.");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    await _sqlConnection.CloseAsync();
                }
            }
        }

    }
}
