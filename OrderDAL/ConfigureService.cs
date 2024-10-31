using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDAL.Data;
using OrderDAL.Data.Repositories;
using OrderDAL.Interfaces;
using OrderDAL.Interfaces.Repositories;
namespace OrderDAL
{
    public static class ConfigureService
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MSSQLConnectionOrders")));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();
            services.AddTransient<IUnitOfWorkEF, UnitOfWorkEF>();   

            return services;
        }
    }
}
