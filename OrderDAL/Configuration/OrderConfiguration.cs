using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDAL.Entities;
using OrderDAL.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalPrice)
                   .HasColumnType("decimal(10,2)");

            builder.Property(o => o.Status)
                   .HasMaxLength(50);


            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            new OrderSeeder().Seed(builder);
        }
    }
}
