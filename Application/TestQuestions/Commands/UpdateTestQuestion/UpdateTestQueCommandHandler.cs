using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Commands.UpdateTestQuestion
{
    public class UpdateTestQueCommandHandler: IRequestHandler<UpdateTestQueCommand, int>
    {
        private readonly ITestQuestionRepository testQuestionRepository;

        public UpdateTestQueCommandHandler(ITestQuestionRepository testQuestionRepository)
        {
            this.testQuestionRepository = testQuestionRepository;
        }

        public async Task<int> Handle(UpdateTestQueCommand request, CancellationToken cancellationToken)
        {
            var updatedQuestion = new TestQuestionEntity
            {
                Id = request.Id,
                QuestionText = request.QuestionText,
                TestId = request.TestId,
            };

            return await testQuestionRepository.UpdateAsync(request.Id, updatedQuestion);

        }
    }
}
