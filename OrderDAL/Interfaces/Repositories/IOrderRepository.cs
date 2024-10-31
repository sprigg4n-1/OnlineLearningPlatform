using OrderDAL.Entities;
using OrderDAL.Pagination;
using OrderDAL.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Interfaces.Repositories
{
    public interface IOrderRepository: IGenericRepositoryEF<OrderEntity>
    {
        Task<PagedList<OrderEntity>> GetAllByParametersAsync(OrderParameters parameters);
        Task<IEnumerable<OrderEntity>> GetAllByCourseIdAsync(int courseId);
        Task<IEnumerable<PaymentEntity>> GetPaymentsByOrderIdAsync(int orderId);
        Task AddPaymentAsync(int orderId, PaymentEntity payment);
    }
}
