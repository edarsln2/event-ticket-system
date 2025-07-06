using Microsoft.AspNetCore.Mvc;
using EventTicketSystem.Application;
using System.Text.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

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
        public async Task<IActionResult> Handle([FromHeader(Name = "action")] string action, [FromBody] JsonElement body)
        {
            var actionDefinition = ActionStorage.Actions[action];

            var request = actionDefinition.MethodParamType == null ? null : body.Deserialize(actionDefinition.MethodParamType);

            if (actionDefinition.ValidationType != null)
            {
                var validatorInstance = (IValidator)Activator.CreateInstance(actionDefinition.ValidationType)!;
                var validationResult = await validatorInstance.ValidateAsync(new ValidationContext<object>(request));
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
            }

            var method = typeof(EventApplication).GetMethod(actionDefinition.MethodName);
            var response = actionDefinition.MethodParamType == null ? method.Invoke(_application, null) : method.Invoke(_application, new[] { request });

            return Ok(response);
        }
    }
}