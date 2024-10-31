using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Parameters
{
    public class OrderParameters: QueryStringParameters
    {
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}
