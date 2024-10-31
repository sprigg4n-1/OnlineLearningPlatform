using OrderBLL.DTO.Request;
using OrderBLL.DTO.Response;
using OrderDAL.Pagination;
using OrderDAL.Parameters;


namespace OrderBLL.Interfaces
{
    public interface IOrderService
    {
        Task<PagedList<OrderResponse>> GetAllByParametersAsync(OrderParameters parameters);
        Task<OrderResponse> GetByIdAsync(int id);
        Task<IEnumerable<OrderResponse>> GetAllByCourseIdAsync(int courseId);
        Task<IEnumerable<PaymentResponse>> GetPaymentsByOrderIdAsync(int orderId);
        Task AddPaymentAsync(int orderId, PaymentRequest payment);
        Task InsertAsync(OrderRequest request);
        Task UpdateAsync(OrderRequest request);
        Task DeleteAsync(int id);
    }
}
