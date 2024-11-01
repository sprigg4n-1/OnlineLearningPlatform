using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.UpdateTest
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, int>
    {
        private readonly ITestRepository testRepository;

        public UpdateTestCommandHandler(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }
        public async Task<int> Handle(UpdateTestCommand request, CancellationToken cancellationToken)

        {
            var updatedTest = new TestEntity { 
                Id = request.Id, 
                Title = request.Title,
                Description = request.Description,
                TimeLimit = request.TimeLimit,
                CourseId = request.CourseId,
            };

            return await testRepository.UpdateAsync(request.Id, updatedTest);
        }
    }
}
