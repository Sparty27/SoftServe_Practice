using Microsoft.AspNetCore.Mvc;
using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;

namespace SoftServe_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionsController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet("GetAllSessions")]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            try
            {
                var sessions = await _sessionRepository.GetSessionsAsync();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetSessionById")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            try
            {
                var session = await _sessionRepository.GetSessionByIdAsync(id);
                if (session == null)
                {
                    return NotFound();
                }
                return Ok(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Filter")]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessionsByFilter([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] string? genre)
        {
            var sessions = await _sessionRepository.GetSessionsByFilterAsync(startDate, endDate, genre);
            return Ok(sessions);
        }

        [HttpPost("CreateSession")]
        public async Task<ActionResult> AddSession(Session session)
        {
            try
            {
                await _sessionRepository.AddSessionAsync(session);
                return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateSession")]
        public async Task<ActionResult> UpdateSession(int id, Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != session.Id)
                {
                    return BadRequest();
                }
                await _sessionRepository.UpdateSessionAsync(session);
                return Ok(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteSession")]
        public async Task<ActionResult> DeleteSession(int id)
        {
            try
            {
                await _sessionRepository.DeleteSessionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
