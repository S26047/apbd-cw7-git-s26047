using Microsoft.EntityFrameworkCore;
using MiniHelpdesk.Data;
using MiniHelpdesk.Models;
using MiniHelpdesk.Repositories.Interfaces;
using MiniHelpdesk.Services.Interfaces;

namespace MiniHelpdesk.Services;

public class TicketService : ITicketService
{
    private readonly HelpdeskContext _context;
    private readonly ITicketRepository _ticketRepository;
    private readonly ITicketCommentRepository _commentRepository;

    public TicketService(
        HelpdeskContext context,
        ITicketRepository ticketRepository,
        ITicketCommentRepository commentRepository)
    {
        _context = context;
        _ticketRepository = ticketRepository;
        _commentRepository = commentRepository;
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

    public async Task CreateAsync(CreateTicketViewModel model)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var ticket = new Ticket
            {
                Title = model.Title,
                Description = model.Description,
                Status = "Open",
                CreatedAt = DateTime.Now
            };

            await _ticketRepository.AddAsync(ticket);
            await _ticketRepository.SaveChangesAsync();

            var comment = new TicketComment
            {
                TicketId = ticket.Id,
                Author = model.Author,
                Content = model.FirstComment,
                CreatedAt = DateTime.Now
            };

            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}