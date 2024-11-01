using Application.TestQuestions.Queries.GetTestQuestions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Commands.CreateTestQuestion
{
    public class CreateTestQueCommand: IRequest<TestQuestionVm>
    {
        public string QuestionText { get; set; }
        public int TestId { get; set; }

    }
}
