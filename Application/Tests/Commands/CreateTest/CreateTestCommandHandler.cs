using Application.Tests.Queries.GetTests;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.CreateTest
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, TestVm>
    {
        private readonly ITestRepository testRepository;
        private readonly IMapper mapper;

        public CreateTestCommandHandler(ITestRepository testRepository, IMapper mapper)
        {
            this.testRepository = testRepository;
            this.mapper = mapper;
        }
        public async Task<TestVm> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var createdTest = new TestEntity()
            {
                Title = request.Title,
                Description = request.Description,
                TimeLimit = request.TimeLimit,
                CourseId = request.CourseId,
            };

            var res = await testRepository.CreateAsync(createdTest);

            return mapper.Map<TestVm>(res);
        }
    }
}
