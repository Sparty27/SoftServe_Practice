using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace SoftServe_Practice.Models
{
    public class SessionTicketPrice
    {
        public int SessionId { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public Session Session { get; set; }

        public int TicketPriceId { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public TicketPrice TicketPrice { get; set; }
    }
}
