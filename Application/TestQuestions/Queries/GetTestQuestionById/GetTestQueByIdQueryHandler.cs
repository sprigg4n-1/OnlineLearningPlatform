using Application.TestQuestions.Queries.GetTestQuestions;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Queries.GetTestQuestionById
{
    public class GetTestQueByIdQueryHandler : IRequestHandler<GetTestQueByIdQuery, TestQuestionVm>
    {
        private readonly ITestQuestionRepository testQuestionRepository;
        private readonly IMapper mapper;

        public GetTestQueByIdQueryHandler(ITestQuestionRepository testQuestionRepository, IMapper mapper)
        {
            this.testQuestionRepository = testQuestionRepository;
            this.mapper = mapper;
        }
        public async Task<TestQuestionVm> Handle(GetTestQueByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await testQuestionRepository.GetByIdAsync(request.Id);

            return mapper.Map<TestQuestionVm>(question);
        }
    }
}
