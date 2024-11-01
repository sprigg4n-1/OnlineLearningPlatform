using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Commands.DeleteTestQuestion
{
    public class DeleteTestQueCommandHandler: IRequestHandler<DeleteTestQueCommand, int>
    {
        private readonly ITestQuestionRepository testQuestionRepository;

        public DeleteTestQueCommandHandler(ITestQuestionRepository testQuestionRepository)
        {
            this.testQuestionRepository = testQuestionRepository;
        }

        public async Task<int> Handle(DeleteTestQueCommand request, CancellationToken cancellationToken)
        {
            return await testQuestionRepository.DeleteAsync(request.Id);
        }
    }
}
