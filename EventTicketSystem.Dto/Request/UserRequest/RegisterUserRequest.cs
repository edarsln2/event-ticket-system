namespace EventTicketSystem.Dto.Request.UserRequest
{
    public class RegisterUserRequest : RequestBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
