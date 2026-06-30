using Microsoft.EntityFrameworkCore;
using MiniHelpdesk.Models;

namespace MiniHelpdesk.Data;

public class HelpdeskContext : DbContext
{
    public HelpdeskContext(DbContextOptions<HelpdeskContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<TicketComment> TicketComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ticket>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.Ticket)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}