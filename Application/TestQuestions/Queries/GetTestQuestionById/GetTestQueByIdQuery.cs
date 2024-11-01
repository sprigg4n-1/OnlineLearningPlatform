using Application.TestQuestions.Queries.GetTestQuestions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Queries.GetTestQuestionById
{
    public class GetTestQueByIdQuery: IRequest<TestQuestionVm>
    {
        public int Id { get; set; } 
    }
}
