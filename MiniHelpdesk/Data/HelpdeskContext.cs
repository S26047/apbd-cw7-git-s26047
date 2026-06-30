using Microsoft.EntityFrameworkCore;

namespace MiniHelpdesk.Data;

public class HelpdeskContext : DbContext
{
    public HelpdeskContext(DbContextOptions<HelpdeskContext> options)
        : base(options)
    {
    }
}