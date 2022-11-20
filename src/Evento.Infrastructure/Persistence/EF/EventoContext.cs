using Evento.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infrastructure.Persistence.EF;

public class EventoContext : DbContext
{
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public EventoContext(DbContextOptions options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventoContext).Assembly);
}
