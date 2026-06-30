using System.ComponentModel.DataAnnotations;

namespace MiniHelpdesk.Models;

public class CreateTicketViewModel
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public string FirstComment { get; set; } = string.Empty;
}