using AutoMapper;
using OrderBLL.DTO.Request;
using OrderBLL.DTO.Response;
using OrderDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Configuration
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {
            CreateOrderMapps();
            CreatePaymentMapps();
        }

        private void CreateOrderMapps()
        {
            CreateMap<OrderRequest, OrderEntity>();
            CreateMap<OrderEntity, OrderRequest>();
            CreateMap<OrderEntity, OrderResponse>()
                .ForMember(
                    response => response.TotalPayments,
                    options => options.MapFrom(order => order.Payments.Sum(payment => payment.Amount)) 
                )
                .ForMember(
                    response => response.PaymentMethod,
                    options => options.MapFrom(order => order.Payments.Any() ? order.Payments.First().PaymentMethod : null)
                );

        }

        private void CreatePaymentMapps()
        {
            CreateMap<PaymentEntity, PaymentResponse>();
            CreateMap<PaymentRequest, PaymentEntity>();
        }
    }
}
