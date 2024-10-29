using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDAL.Entities;
using OrderDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OrderDAL.Seeding
{
    public class OrderSeeder : ISeeder<OrderEntity>
    {
        private static readonly List<OrderEntity> orders = new()
        {
            new OrderEntity
            {
                Id = 1,
                UserId = 101,
                CourseId = 202,
                OrderDate = DateTime.Now,
                TotalPrice = 299.99m,
                Status = "pending",
            },
            new OrderEntity
            {
                Id = 2,
                UserId = 102,
                CourseId = 203,
                OrderDate = DateTime.Now,
                TotalPrice = 199.99m,
                Status = "completed",
            }
        };

        public void Seed(EntityTypeBuilder<OrderEntity> builder) => builder.HasData(orders);
    }
}
