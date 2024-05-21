using Microsoft.EntityFrameworkCore;
using SoftServe_Practice.Data;
using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;

namespace SoftServe_Practice.Repositories
{
    public class TicketPriceRepository : ITicketPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketPriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketPrice>> GetTicketPricesAsync()
        {
            return await _context.TicketPrices
                .Include(tp => tp.SessionTicketPrices)
                .ThenInclude(stp => stp.Session)
                .ToListAsync();
        }

        public async Task<TicketPrice> GetTicketPriceByIdAsync(int id)
        {
            return await _context.TicketPrices
                .Include(tp => tp.SessionTicketPrices)
                .ThenInclude(stp => stp.Session)
                .FirstOrDefaultAsync(tp => tp.Id == id);
        }

        public async Task AddTicketPriceAsync(TicketPrice ticketPrice)
        {
            _context.TicketPrices.Add(ticketPrice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketPriceAsync(TicketPrice ticketPrice)
        {
            _context.TicketPrices.Update(ticketPrice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketPriceAsync(int id)
        {
            var ticketPrice = await _context.TicketPrices.FindAsync(id);
            if (ticketPrice != null)
            {
                _context.TicketPrices.Remove(ticketPrice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
