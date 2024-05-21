using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SoftServe_Practice.Models
{
    public class SessionTicketPrice
    {
        public int SessionId { get; set; }

        [ValidateNever]
        public Session Session { get; set; }

        public int TicketPriceId { get; set; }

        [ValidateNever]
        public TicketPrice TicketPrice { get; set; }
    }
}
