using Microsoft.EntityFrameworkCore;
using OrderDAL.Entities;
using OrderDAL.Exceptions;
using OrderDAL.Interfaces.Repositories;
using OrderDAL.Pagination;
using OrderDAL.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data.Repositories
{
    public class OrderRepository : GenericRepositoryEF<OrderEntity>, IOrderRepository
    {
        public OrderRepository(OrderDbContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<PagedList<OrderEntity>> GetAllByParametersAsync(OrderParameters parameters)
        {

            IQueryable<OrderEntity> sourse = table.Include(order => order.Payments);

            SearchByUserId(ref sourse, parameters.UserId);
            ServchByStatus(ref sourse, parameters.Status);

            return await PagedList<OrderEntity>.ToPagedListAsync(
                sourse,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public static void SearchByUserId(ref IQueryable<OrderEntity> sourse, int userId)
        {
            if (userId == 0)
            {
                return;
            }
            sourse = sourse.Where(order => order.UserId == userId);
        }

        public static void ServchByStatus(ref IQueryable<OrderEntity> sourse, string status)
        {
            if (string.IsNullOrWhiteSpace(status)) {
                return;
            }

            sourse = sourse.Where(order => order.Status.Equals(status));
        }

        public async Task<IEnumerable<OrderEntity>> GetAllByCourseIdAsync(int courseId)
        {
            return await table.Include(order => order.Payments).Where(order => order.CourseId == courseId).ToListAsync();
        }

        public async Task AddPaymentAsync(int orderId, PaymentEntity payment)
        {
            var order = await table.Include(o => o.Payments).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(orderId));

            order.Payments.Add(payment);
        }



        public async Task<IEnumerable<PaymentEntity>> GetPaymentsByOrderIdAsync(int orderId)
        {
            var order = await table.Include(o => o.Payments).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(orderId));

            return order.Payments;
        }

        public override async Task<OrderEntity> GetCompleteEntityAsync(int id)
        {
            var order = await table.Include(o => o.Payments).FirstOrDefaultAsync(o => o.Id == id);

            return order ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }
    }
}
