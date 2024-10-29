using OrderDAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Interfaces
{
    public interface IUnitOfWorkEF
    {
        IOrderRepository OrderRepository { get; }
        IPaymentsRepository PaymentsRepository { get; }
        Task SaveChangsAsync();
    }
}
