using OrderDAL.Interfaces;
using OrderDAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data
{
    public class UnitOfWorkEF : IUnitOfWorkEF
    {
        private readonly OrderDbContext databaseContext;

        public IOrderRepository OrderRepository { get; }

        public IPaymentsRepository PaymentsRepository { get; }

        public UnitOfWorkEF(OrderDbContext databaseContext, IOrderRepository orderRepository, IPaymentsRepository paymentsRepository) {
            this.databaseContext = databaseContext;
            OrderRepository = orderRepository;
            PaymentsRepository = paymentsRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
