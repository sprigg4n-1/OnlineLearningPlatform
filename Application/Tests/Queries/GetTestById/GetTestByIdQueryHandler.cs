using Application.Tests.Queries.GetTests;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Queries.GetTestById
{
    public class GetTestByIdQueryHandler : IRequestHandler<GetTestByIdQuery, TestVm>
    {
        private readonly ITestRepository testRepository;
        private readonly IMapper mapper;

        public GetTestByIdQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            this.testRepository = testRepository;
            this.mapper = mapper;
        }
        public async Task<TestVm> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var test = await testRepository.GetByIdAsync(request.Id);

            return mapper.Map<TestVm>(test);
        }
    }
}
