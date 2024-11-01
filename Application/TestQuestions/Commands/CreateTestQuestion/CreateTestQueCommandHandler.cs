using Application.TestQuestions.Queries.GetTestQuestions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.TestQuestions.Commands.CreateTestQuestion
{
    public class CreateTestQueCommandHandler: IRequestHandler<CreateTestQueCommand, TestQuestionVm>
    {
        private readonly IMapper mapper;

        private readonly ITestQuestionRepository testQuestionRepository;

        public CreateTestQueCommandHandler(ITestQuestionRepository testQuestionRepository, IMapper mapper)
        {
            this.testQuestionRepository = testQuestionRepository;
            this.mapper = mapper;
        }

        public async Task<TestQuestionVm> Handle(CreateTestQueCommand request, CancellationToken cancellationToken)
        {
            var createdQuestion = new TestQuestionEntity()
            {
                QuestionText = request.QuestionText,
                TestId = request.TestId,
            };

            var res = await testQuestionRepository.CreateAsync(createdQuestion);

            return mapper.Map<TestQuestionVm>(res);
        }
    }
}
