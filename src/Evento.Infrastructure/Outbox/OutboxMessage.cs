namespace Evento.Infrastructure.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public string Type { get; set; } = default!;

    public string Data { get; set; } = default!;

    public DateTimeOffset OccurredOn { get; set; }

    public DateTimeOffset? ProcessedOn { get; set; }

    public OutboxMessage(
        DateTimeOffset occurredOn,
        string type,
        string data)
    {
        Id = Guid.NewGuid();
        OccurredOn = occurredOn;
        Type = type;
        Data = data;
    }

    private OutboxMessage() { }
}
