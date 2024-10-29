using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();

            optionsBuilder.UseSqlServer("Data Source=WINDOWS-05UFGJN;Initial Catalog=orders;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
