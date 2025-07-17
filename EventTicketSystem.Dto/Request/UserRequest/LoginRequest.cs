namespace EventTicketSystem.Dto.Request.UserRequest
{
    public class LoginRequest : RequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
