using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDAL.Entities;
using OrderDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Seeding
{
    public class PaymentsSeeder : ISeeder<PaymentEntity>
    {
        private static readonly List<PaymentEntity> payments = new()
        {
            new PaymentEntity
            {
                Id = 1,
                OrderId = 2,
                Amount = 199.99m,
                PaymentMethod = "credit card",
                Status = "completed",
                TransactionId = "TX1234567890"
            }
        };

        public void Seed(EntityTypeBuilder<PaymentEntity> builder) => builder.HasData(payments);
    }
}
