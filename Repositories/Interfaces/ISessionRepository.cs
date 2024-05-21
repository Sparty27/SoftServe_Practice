using SoftServe_Practice.Models;

namespace SoftServe_Practice.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync();
        Task<Session> GetSessionByIdAsync(int id);
        Task AddSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task DeleteSessionAsync(int id);
    }
}
