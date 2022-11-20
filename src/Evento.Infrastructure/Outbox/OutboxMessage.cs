namespace Evento.Infrastructure.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }

    public DateTime OccurredOn { get; set; }

    public DateTime? ProcessedOn { get; set; }

    public OutboxMessage(
        DateTime occurredOn,
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
