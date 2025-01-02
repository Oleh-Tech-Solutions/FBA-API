using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Domain.Data.Transactions;
using FamilyBudgeting.Infrastructure.Utilities;

namespace FamilyBudgeting.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public TransactionRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            string query = @"
                    INSERT INTO [Transaction]
                           ([AuthorId]
                           ,[LedgerId]
                           ,[TransactionTypeId]
                           ,[Amount]
                           ,[Date]
                           ,[Note])
                     VALUES
                           (@AuthorId
                           ,@LedgerId
                           ,@TransactionTypeId
                           ,@Amount
                           ,@Date
                           ,@Note);
                    SELECT SCOPE_IDENTITY();
                    ";

            QueryLogger.LogQuery(query, transaction);

            using (var conn = _connectionFactory.GetOpenConnection())
            {
                return await conn.ExecuteScalarAsync<int>(query,
                    new
                    {
                        AuthorId = transaction.AuthorId,
                        LedgerId = transaction.LedgerId,
                        TransactionTypeId = transaction.TransactionTypeId,
                        Amount = transaction.Amount,
                        Date = transaction.Date,
                        Note = transaction.Note
                    });
            }
        }
    }
}
