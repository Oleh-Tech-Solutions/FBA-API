using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Domain.Data.Ledgers;
using FamilyBudgeting.Infrastructure.Utilities;

namespace FamilyBudgeting.Infrastructure.Repositories
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public LedgerRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateLedgerAsync(bool closeConnection = false)
        {
            string query = @"
                INSERT INTO [Ledger]
                DEFAULT VALUES; 
                SELECT SCOPE_IDENTITY();
                ";

            QueryLogger.LogQuery(query, null);

            var conn = _connectionFactory.GetOpenConnection();
            int ledgerId = await conn.ExecuteScalarAsync<int>(query);

            if (closeConnection)
            {
                conn.Close();
            }

            return ledgerId;
        }
    }
}
