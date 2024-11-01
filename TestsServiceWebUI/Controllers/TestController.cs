using Application.Tests.Commands.CreateTest;
using Application.Tests.Commands.DeleteTest;
using Application.Tests.Commands.UpdateTest;
using Application.Tests.Queries.GetTestById;
using Application.Tests.Queries.GetTests;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tests = await Mediator.Send(new GetTestQuery());

            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var test = await Mediator.Send(new GetTestByIdQuery() { Id = id});

            if (test == null) return NotFound();

            return Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestCommand command)
        {
            var res = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTestCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest();
            }

            Console.WriteLine(id + "; " + command.Id);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await Mediator.Send(new DeleteTestCommand { Id = id});

            if (res == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
