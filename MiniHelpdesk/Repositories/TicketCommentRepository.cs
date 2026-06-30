using Microsoft.EntityFrameworkCore;
using MiniHelpdesk.Data;
using MiniHelpdesk.Models;
using MiniHelpdesk.Repositories.Interfaces;

namespace MiniHelpdesk.Repositories;

public class TicketCommentRepository : ITicketCommentRepository
{
    private readonly HelpdeskContext _context;

    public TicketCommentRepository(HelpdeskContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TicketComment comment)
    {
        await _context.TicketComments.AddAsync(comment);
    }

    public async Task<List<TicketComment>> GetByTicketIdAsync(int ticketId)
    {
        return await _context.TicketComments
            .Where(c => c.TicketId == ticketId)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}