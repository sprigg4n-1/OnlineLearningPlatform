using Microsoft.EntityFrameworkCore;
using OrderDAL.Configuration;
using OrderDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }
    }
}
