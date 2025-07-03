using Microsoft.AspNetCore.Mvc;
using EventTicketSystem.Application;
using System.Text.Json;
using FluentValidation;

namespace EventTicketSystem.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class EventController : ControllerBase
    {
        private readonly EventApplication _application;

        public EventController(EventApplication application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<IActionResult> Handle(
            [FromHeader(Name = "action")] string action,
            [FromBody] JsonElement body)
        {
            var actionDefination = ActionStorage.Actions[action];
            var model = actionDefination.MethodParamType != null ? body.Deserialize(actionDefination.MethodParamType) : null;

            if (actionDefination.ValidationType != null)
            {
                var validator = (IValidator)HttpContext.RequestServices.GetRequiredService(actionDefination.ValidationType);
                var context = new ValidationContext<object>(model);
                var result = await validator.ValidateAsync(context);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
            }

            var app = HttpContext.RequestServices.GetRequiredService(actionDefination.ApplicationType);
            var method = actionDefination.ApplicationType.GetMethod(actionDefination.MethodName);
            var response = method.Invoke(app, model != null ? new[] { model } : null);

            return Ok(response);
        }
    }
}
