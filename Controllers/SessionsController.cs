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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            var sessions = await _sessionRepository.GetSessionsAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _sessionRepository.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult> AddSession(Session session)
        {
            await _sessionRepository.AddSessionAsync(session);
            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSession(int id, Session session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }
            await _sessionRepository.UpdateSessionAsync(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSession(int id)
        {
            await _sessionRepository.DeleteSessionAsync(id);
            return NoContent();
        }
    }
}
