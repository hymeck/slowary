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
        public async Task<IActionResult> GetSign(uint id)
        {
            var query = new GetSignByIdQuery(id);
            var result = await Mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
        
        [HttpPost("create")]
        public async Task<ActionResult<uint>> Create(SignCreateCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction("GetSign", new {id = result.SignId}, result);
        }
    }
}