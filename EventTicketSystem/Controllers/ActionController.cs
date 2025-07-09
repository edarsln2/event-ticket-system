using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FluentValidation;
using EventTicketSystem.WebApi.ApplicationStorage;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EventTicketSystem.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class EventController : ControllerBase
    {
        private readonly ApplicationStorage _applicationStorage;

        public EventController(ApplicationStorage applicationStorage)
        {
            _applicationStorage = applicationStorage;
        }

        [HttpPost]
        public async Task<IActionResult> Handle(
            [FromHeader(Name = "action")] string action,
            [FromBody] JsonElement body)
        {
            var actionDefinition = ActionStorage.Actions[action];

            object? request = null;

            if (actionDefinition.MethodParamType != null)
            {
                request = body.Deserialize(actionDefinition.MethodParamType);
            }

            if (actionDefinition.ValidationType != null)
            {
                var validator = (IValidator)Activator.CreateInstance(actionDefinition.ValidationType)!;
                var validationResult = await validator.ValidateAsync(new ValidationContext<object>(request!));
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
            }

            var application = _applicationStorage.GetApplication(actionDefinition.ApplicationType);
            var method = actionDefinition.ApplicationType.GetMethod(actionDefinition.MethodName);

            if (method == null)
            {
                return BadRequest("Metot bulunamadý.");
            }

            object? response;

            var parameters = method.GetParameters();

            if (parameters.Length == 0)
            {
                response = method.Invoke(application, null);
            }
            else if (parameters.Length == 1 && parameters[0].ParameterType == typeof(ClaimsPrincipal))
            {
                response = method.Invoke(application, new object[] { User });
            }
            else if (parameters.Length == 2 && parameters[1].ParameterType == typeof(ClaimsPrincipal))
            {
                response = method.Invoke(application, new object[] { request!, User });
            }
            else
            {
                response = method.Invoke(application, new[] { request });
            }

            return Ok(response);
        }
    }
}
