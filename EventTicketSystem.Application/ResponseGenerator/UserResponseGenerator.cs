using EventTicketSystem.Dto.Response;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Application.ResponseGenerators
{
    public static class UserResponseGenerator
    {
        public static RegisterUserResponse ToRegisterUserResponse(User user)
        {
            return new RegisterUserResponse
            {
                UserId = user.UserId
            };
        }
    }
}
