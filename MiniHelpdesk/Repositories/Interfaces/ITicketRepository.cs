using MiniHelpdesk.Models;

namespace MiniHelpdesk.Repositories.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task SaveChangesAsync();
}