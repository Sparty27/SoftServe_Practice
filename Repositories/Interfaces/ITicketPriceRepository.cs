using SoftServe_Practice.Models;

namespace SoftServe_Practice.Repositories.Interfaces
{
    public interface ITicketPriceRepository
    {
        Task<IEnumerable<TicketPrice>> GetTicketPricesAsync();
        Task<TicketPrice> GetTicketPriceByIdAsync(int id);
        Task AddTicketPriceAsync(TicketPrice ticketPrice);
        Task UpdateTicketPriceAsync(TicketPrice ticketPrice);
        Task DeleteTicketPriceAsync(int id);
    }
}
