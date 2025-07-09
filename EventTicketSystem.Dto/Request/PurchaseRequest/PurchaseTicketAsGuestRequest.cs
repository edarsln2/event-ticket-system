
namespace EventTicketSystem.Dto.Request.PurchaseRequest
{
    public class PurchaseTicketAsGuestRequest
    {
        public string FullName { get; set; } 
        public string Email { get; set; }     
        public int EventId { get; set; }
        public int Quantity { get; set; }
    }    
}
