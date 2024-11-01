using Application.Tests.Queries.GetTests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.CreateTest
{
    public class CreateTestCommand: IRequest<TestVm>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int CourseId { get; set; }
    }
}
