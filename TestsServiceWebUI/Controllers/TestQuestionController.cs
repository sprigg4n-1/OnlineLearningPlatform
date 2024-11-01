using Application.TestQuestions.Commands.CreateTestQuestion;
using Application.TestQuestions.Commands.DeleteTestQuestion;
using Application.TestQuestions.Commands.UpdateTestQuestion;
using Application.TestQuestions.Queries.GetTestQuestionById;
using Application.TestQuestions.Queries.GetTestQuestions;
using Application.Tests.Commands.CreateTest;
using Application.Tests.Commands.DeleteTest;
using Application.Tests.Commands.UpdateTest;
using Application.Tests.Queries.GetTestById;
using Application.Tests.Queries.GetTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await Mediator.Send(new GetTestQueQuery());

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await Mediator.Send(new GetTestQueByIdQuery() { Id = id });

            if (question == null) return NotFound();

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestQueCommand command)
        {
            var res = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTestQueCommand command)
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
            var res = await Mediator.Send(new DeleteTestQueCommand { Id = id });

            if (res == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
