using Application.Tests.Queries.GetTests;
using MediatR;

namespace Application.Tests.Queries.GetTestById
{
    public class GetTestByIdQuery : IRequest<TestVm>
    {
        public int Id { get; set; }
    }
}
