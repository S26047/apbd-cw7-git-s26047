using MiniHelpdesk.Models;
using MiniHelpdesk.Repositories.Interfaces;
using MiniHelpdesk.Services.Interfaces;

namespace MiniHelpdesk.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }

    public async Task CloseAsync(int id)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id);

        if (ticket == null)
            throw new Exception("Ticket not found.");

        ticket.Status = "Closed";

        await _ticketRepository.UpdateAsync(ticket);
        await _ticketRepository.SaveChangesAsync();
    }
}