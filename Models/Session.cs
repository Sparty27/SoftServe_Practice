using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SoftServe_Practice.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ID фільму є обов'язковим.")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Час початку сеансу є обов'язковим.")]
        public DateTime StartTime { get; set; }

        //[Required(ErrorMessage = "Ціна квитка є обов'язковою.")]
        //[Range(0, 1000, ErrorMessage = "Ціна квитка повинна бути від 0 до 1000.")]
        //public decimal TicketPrice { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public Movie Movie { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<SessionTicketPrice> SessionTicketPrices { get; set; }
    }
}