using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Evento.Infrastructure.Outbox.EF;

public class OutboxMessageDapperRepository : IOutboxMessageRepository
{
    private readonly SqlConnection _sqlConnection;
    private readonly IDbTransaction _dbTransaction;

    public OutboxMessageDapperRepository(
        SqlConnection sqlConnection,
        IDbTransaction dbTransaction)
    {
        _sqlConnection = sqlConnection;
        _dbTransaction = dbTransaction;
    }

    public Task<List<OutboxMessage>> GetUnprocessedMessagesAsync(int count, CancellationToken ct) 
        => throw new NotImplementedException();

    public async Task InsertAsync(IEnumerable<OutboxMessage> messages, CancellationToken ct = default) 
    {
        string sql = "Insert OutboxMessages";
        await _sqlConnection.ExecuteAsync(sql, new { }, _dbTransaction, commandType: CommandType.Text);
    }
    
    Task IOutboxMessageRepository.UpdateProcessOnAsync(IEnumerable<Guid> outboxIds, CancellationToken ct) 
        => throw new NotImplementedException();
}
