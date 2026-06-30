using MiniHelpdesk.Models;

namespace MiniHelpdesk.Repositories.Interfaces;

public interface ITicketCommentRepository
{
    Task AddAsync(TicketComment comment);
    Task<List<TicketComment>> GetByTicketIdAsync(int ticketId);
    Task SaveChangesAsync();
}