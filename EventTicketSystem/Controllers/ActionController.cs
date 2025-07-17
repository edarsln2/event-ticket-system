using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FluentValidation;
using EventTicketSystem.WebApi.ApplicationStorage;
using System.Security.Claims;
using EventTicketSystem.Dto.Request;

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
            if (!ActionStorage.Actions.TryGetValue(action, out var actionDefinition))
            {
                return BadRequest("Geçersiz action.");
            }

            var request = body.Deserialize(actionDefinition.MethodParamType);

            if (request is RequestBase requestBase)
            {
                requestBase.UserInfo = User;

                if (requestBase.LoginRequired)
                {
                    if (!User.Identity?.IsAuthenticated ?? true)
                    {
                        return Unauthorized();
                    }

                    if (User.FindFirst(ClaimTypes.NameIdentifier) == null)
                    {
                        return Forbid();
                    }

                    if (actionDefinition.Role != null)
                    {
                        var role = User.FindFirst(ClaimTypes.Role)?.Value?.ToLower();
                        if (role != actionDefinition.Role.ToLower())
                        {
                            return Forbid($"Bu iþlem için '{actionDefinition.Role}' rolü gereklidir.");
                        }
                    }
                }
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

            var response = method.Invoke(application, new[] { request });
            return Ok(response);
        }
    }
}

 
