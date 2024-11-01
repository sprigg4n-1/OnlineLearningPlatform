using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer("Data Source=WINDOWS-05UFGJN;Initial Catalog=tests-course;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));

            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestQuestionRepository, TestQuestionRepository>();
            services.AddTransient<ICacheService, MemoryCacheService>();

            return services;
        } 
    }
}
