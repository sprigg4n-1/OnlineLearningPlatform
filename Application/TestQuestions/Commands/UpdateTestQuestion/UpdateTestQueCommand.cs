using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Commands.UpdateTestQuestion
{
    public class UpdateTestQueCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
    }
}
