using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.UpdateTest
{
    public class UpdateTestCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int CourseId { get; set; }
    }
}
