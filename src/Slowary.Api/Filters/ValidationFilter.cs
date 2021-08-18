using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Slowary.Api.Models;

namespace Slowary.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
                await next();

            // todo: what about 422?

            var errors = BuildErrors(context.ModelState);
            context.Result = new BadRequestObjectResult(errors);
        }

        private ValidationErrorModelCollection BuildErrors(ModelStateDictionary state)
        {
            var result = state
                .Where(kvp => kvp.Value.Errors.Count > 0)
                .Select(kvp =>
                    new ValidationErrorModel(kvp.Key, kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()))
                .ToArray();

            return new ValidationErrorModelCollection(result);
        }
    }
}