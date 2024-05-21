using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SoftServe_Practice.Models
{
    public class TicketPrice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Категорія квитка є обов'язковою.")]
        [StringLength(50, ErrorMessage = "Категорія квитка не може бути довшою за 50 символів.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Ціна квитка є обов'язковою.")]
        [Range(0, 1000, ErrorMessage = "Ціна квитка повинна бути від 0 до 1000.")]
        public decimal Price { get; set; }

        [ValidateNever]
        public ICollection<SessionTicketPrice> SessionTicketPrices { get; set; }
    }
}
