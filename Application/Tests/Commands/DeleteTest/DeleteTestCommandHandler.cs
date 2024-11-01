using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.DeleteTest
{
    public class DeleteTestCommandHandler: IRequestHandler<DeleteTestCommand, int>
    {
        private readonly ITestRepository testRepository;

        public DeleteTestCommandHandler(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task<int> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            return await testRepository.DeleteAsync(request.Id);
        }
    }
}
