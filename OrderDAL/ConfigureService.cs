using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDAL.Data;
namespace OrderDAL
{
    public static class ConfigureService
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MSSQLConnectionOrders")));

            return services;
        }
    }
}
