using OrderDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Interfaces.Repositories
{
    public interface IPaymentsRepository: IGenericRepositoryEF<PaymentEntity>
    {
    }
}
