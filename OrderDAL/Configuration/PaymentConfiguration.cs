using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDAL.Entities;
using OrderDAL.Seeding;

namespace OrderDAL.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.PaymentMethod)
                   .HasMaxLength(50);

            builder.Property(p => p.Status)
                   .HasMaxLength(50);

            builder.Property(p => p.TransactionId)
                   .HasMaxLength(100);

            new PaymentsSeeder().Seed(builder);
        }
    }
}
