using AutoMapper;
using OrderBLL.DTO.Request;
using OrderBLL.DTO.Response;
using OrderBLL.Interfaces;
using OrderDAL.Entities;
using OrderDAL.Interfaces;
using OrderDAL.Interfaces.Repositories;
using OrderDAL.Pagination;
using OrderDAL.Parameters;


namespace OrderBLL.Services
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWorkEF unitOfWork;
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;
        private readonly IPaymentsRepository paymentsRepository;

        public OrderService(IUnitOfWorkEF unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            orderRepository = this.unitOfWork.OrderRepository;
            paymentsRepository = this.unitOfWork.PaymentsRepository;
        }

        public async Task<PagedList<OrderResponse>> GetAllByParametersAsync(OrderParameters parameters)
        {

            var orders = await orderRepository.GetAllByParametersAsync(parameters);
            return orders.Map(mapper.Map<OrderEntity, OrderResponse>);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllByCourseIdAsync(int courseId)
        {
            var orders = await orderRepository.GetAllByCourseIdAsync(courseId);
            return orders.Select(order => mapper.Map<OrderEntity, OrderResponse>(order));
        }

        public async Task<IEnumerable<PaymentResponse>> GetPaymentsByOrderIdAsync(int orderId)
        {
            var payments = await orderRepository.GetPaymentsByOrderIdAsync(orderId);
            return payments.Select(payment => mapper.Map<PaymentResponse>(payment));
        }

        public async Task AddPaymentAsync(int orderId, PaymentRequest payment)
        {
            var order = await orderRepository.GetByIdAsync(orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }

            var paymentEntity = mapper.Map<PaymentEntity>(payment);
            paymentEntity.OrderId = orderId;

            await paymentsRepository.InsertAsync(paymentEntity);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task InsertAsync(OrderRequest request)
        {
            var orderEntity = mapper.Map<OrderRequest, OrderEntity>(request);
            await orderRepository.InsertAsync(orderEntity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderRequest request)
        {
            var order = mapper.Map<OrderRequest, OrderEntity>(request);
            await orderRepository.UpdateAsync(order);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            await orderRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<OrderResponse> GetByIdAsync(int id)
        {
            var order = await orderRepository.GetCompleteEntityAsync(id);
            return mapper.Map<OrderEntity, OrderResponse>(order);
        }
    }
}
