using System.ComponentModel.DataAnnotations;

namespace MiniHelpdesk.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public string Status { get; set; } = "Open";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}