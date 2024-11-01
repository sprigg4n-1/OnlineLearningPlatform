using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Commands.DeleteTestQuestion
{
    public class DeleteTestQueCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
