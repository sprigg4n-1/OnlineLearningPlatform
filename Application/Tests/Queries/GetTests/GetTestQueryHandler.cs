using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Tests.Queries.GetTests
{
    public class GetTestQueryHandler : IRequestHandler<GetTestQuery, List<TestVm>>
    {
        private readonly ITestRepository testRepository;
        private readonly IMapper mapper;

        public GetTestQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            this.testRepository = testRepository;
            this.mapper = mapper;
        }
        public async Task<List<TestVm>> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var tests = await testRepository.GetAllTestsAsync();

            return mapper.Map<List<TestVm>>(tests);
        }
    }
}
