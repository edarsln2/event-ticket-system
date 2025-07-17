using System.Security.Claims;

namespace EventTicketSystem.Dto.Request
{
    public class RequestBase
    {
        public ClaimsPrincipal? UserInfo { get; set; }
        public virtual bool LoginRequired => false;
    }
}
