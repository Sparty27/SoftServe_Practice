using Microsoft.AspNetCore.Mvc;
using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;

namespace SoftServe_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketPricesController : ControllerBase
    {
        private readonly ITicketPriceRepository _ticketPriceRepository;

        public TicketPricesController(ITicketPriceRepository ticketPriceRepository)
        {
            _ticketPriceRepository = ticketPriceRepository;
        }

        [HttpGet("GetAllTicketPrices")]
        public async Task<ActionResult<IEnumerable<TicketPrice>>> GetTicketPrices()
        {
            var ticketPrices = await _ticketPriceRepository.GetTicketPricesAsync();
            return Ok(ticketPrices);
        }

        [HttpGet("GetTicketPriceById")]
        public async Task<ActionResult<TicketPrice>> GetTicketPrice(int id)
        {
            var ticketPrice = await _ticketPriceRepository.GetTicketPriceByIdAsync(id);
            if (ticketPrice == null)
            {
                return NotFound();
            }
            return Ok(ticketPrice);
        }

        [HttpPost("CreateTicketPrice")]
        public async Task<ActionResult> AddTicketPrice(TicketPrice ticketPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ticketPriceRepository.AddTicketPriceAsync(ticketPrice);
            return CreatedAtAction(nameof(GetTicketPrice), new { id = ticketPrice.Id }, ticketPrice);
        }

        [HttpPut("UpdateTicketPrice")]
        public async Task<ActionResult> UpdateTicketPrice(int id, TicketPrice ticketPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != ticketPrice.Id)
            {
                return BadRequest();
            }
            await _ticketPriceRepository.UpdateTicketPriceAsync(ticketPrice);
            return NoContent();
        }

        [HttpDelete("DeleteTicketPrice")]
        public async Task<ActionResult> DeleteTicketPrice(int id)
        {
            await _ticketPriceRepository.DeleteTicketPriceAsync(id);
            return NoContent();
        }
    }
}
