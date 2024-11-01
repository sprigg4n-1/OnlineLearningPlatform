using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.DeleteTest
{
    public class DeleteTestCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
