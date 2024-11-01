using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Queries.GetTestQuestions
{
    public class GetTestQueQuery: IRequest<List<TestQuestionVm>>
    {
    }
}
