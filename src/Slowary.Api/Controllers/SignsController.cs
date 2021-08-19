using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slowary.Application.Commands.Signs;
using Slowary.Application.Queries.Signs;

namespace Slowary.Api.Controllers
{
    [Route("api/signs")]
    public class SignsController : ApiBaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSign(ulong id)
        {
            var query = new GetSignByIdQuery(id);
            var option = await Mediator.Send(query);
            return option.Match<IActionResult>(Ok, NotFound);
        }
        
        [HttpPost("create")]
        public async Task<ActionResult<uint>> Create([FromBody] SignCreateCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction("GetSign", new {id = result.SignId}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ulong id, [FromBody] SignUpdateCommand command)
        {
            // todo: how to remove it from controller and add descriptive response content?
            if (id != command.SignId)
                return BadRequest();

            await Mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var command = new SignDeleteCommand(id);
            var hasDeleted = await Mediator.Send(command);
            return hasDeleted ? NoContent() : UnprocessableEntity();
        }
    }
}