using Microsoft.EntityFrameworkCore;
using OrderDAL.Entities;
using OrderDAL.Exceptions;
using OrderDAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data.Repositories
{
    public class PaymentsRepository : GenericRepositoryEF<PaymentEntity>, IPaymentsRepository
    {
        public PaymentsRepository(OrderDbContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<PaymentEntity> GetCompleteEntityAsync(int id)
        {
            var payment = await table.Include(p => p.OrderId).SingleOrDefaultAsync(p => p.Id == id);

            return payment ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<IEnumerable<PaymentEntity>> GetPaymentsByMethodAsync(string paymentMethod)
        {
            return await table
            .Where(p => p.PaymentMethod.Equals(paymentMethod, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
        }

        public async Task<IEnumerable<PaymentEntity>> GetPaymentsByUserIdAsync(int userId)
        {
            return await table
            .Include(p => p.Order)
            .Where(p => p.Order.UserId == userId)
            .ToListAsync();
        }
    }
}
