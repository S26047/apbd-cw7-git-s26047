using System.ComponentModel.DataAnnotations;

namespace MiniHelpdesk.Models;

public class TicketComment
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    [Required]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Ticket? Ticket { get; set; }
}