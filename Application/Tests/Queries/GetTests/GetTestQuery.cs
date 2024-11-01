using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Queries.GetTests
{
    public class GetTestQuery: IRequest<List<TestVm>>
    {
    }
}
