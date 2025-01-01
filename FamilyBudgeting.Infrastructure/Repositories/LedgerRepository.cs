using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Domain.Data.Ledgers;

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
            var conn = _connectionFactory.GetOpenConnection();
            int ledgerId = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO [dbo].[Ledger]
                DEFAULT VALUES; 
                SELECT SCOPE_IDENTITY();
                "
            );

            if (closeConnection)
            {
                conn.Close();
            }

            return ledgerId;
        }
    }
}
