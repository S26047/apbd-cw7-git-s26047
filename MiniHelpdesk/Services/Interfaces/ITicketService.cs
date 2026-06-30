using MiniHelpdesk.Models;

namespace MiniHelpdesk.Services.Interfaces;

public interface ITicketService
{
    Task<List<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(int id);
    Task CloseAsync(int id);
}