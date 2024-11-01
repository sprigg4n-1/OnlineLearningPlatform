using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.TestQuestions.Queries.GetTestQuestions
{
    public class GetTestQueQueryHandler : IRequestHandler<GetTestQueQuery, List<TestQuestionVm>>
    {
        private readonly ITestQuestionRepository testQuestionRepository;
        private readonly IMapper mapper;

        public GetTestQueQueryHandler(ITestQuestionRepository testQuestionRepository, IMapper mapper)
        {
            this.testQuestionRepository = testQuestionRepository;
            this.mapper = mapper;
        }
        public async Task<List<TestQuestionVm>> Handle(GetTestQueQuery request, CancellationToken cancellationToken)
        {
            var questions = await testQuestionRepository.GetAllTestsAsync();

            return mapper.Map<List<TestQuestionVm>>(questions);
        }
    }
}
