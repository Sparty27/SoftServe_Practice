using Microsoft.EntityFrameworkCore;
using SoftServe_Practice.Data;
using SoftServe_Practice.Models;
using SoftServe_Practice.Repositories.Interfaces;

namespace SoftServe_Practice.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _context.Sessions.Include(s => s.Movie).ToListAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _context.Sessions.Include(s => s.Movie).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddSessionAsync(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSessionAsync(Session session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
