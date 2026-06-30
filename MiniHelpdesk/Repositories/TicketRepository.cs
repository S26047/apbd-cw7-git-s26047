using Microsoft.EntityFrameworkCore;
using MiniHelpdesk.Data;
using MiniHelpdesk.Models;
using MiniHelpdesk.Repositories.Interfaces;

namespace MiniHelpdesk.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly HelpdeskContext _context;

    public TicketRepository(HelpdeskContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _context.Tickets
            .Include(t => t.Comments)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
    }

    public Task UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}