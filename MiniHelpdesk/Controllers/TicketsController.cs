using Microsoft.AspNetCore.Mvc;
using MiniHelpdesk.Services.Interfaces;

namespace MiniHelpdesk.Controllers;

public class TicketsController : Controller
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public async Task<IActionResult> Index()
    {
        var tickets = await _ticketService.GetAllAsync();
        return View(tickets);
    }
}