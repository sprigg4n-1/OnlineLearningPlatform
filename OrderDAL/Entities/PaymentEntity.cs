using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
