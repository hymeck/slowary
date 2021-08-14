using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Slowary.Api.Controllers
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender _sender;

        protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}