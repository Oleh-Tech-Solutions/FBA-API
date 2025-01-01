using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Domain.Data.UserLedgers;

namespace FamilyBudgeting.Infrastructure.Repositories
{
    public class UserLedgerRepository : IUserLedgerRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserLedgerRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateUserLedgerAsync(UserLedger uLedger, bool closeConnection = false)
        {
            var conn = _connectionFactory.GetOpenConnection();
            int ledgerId = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO [dbo].[UserLedger]
                       ([UserId], [LedgerId] ,[RoleId])
                 VALUES
                       (@UserId, @LedgerId, @RoleId)
                SELECT SCOPE_IDENTITY();
                ", 
                new
                {
                    UserId = uLedger.UserId,
                    LedgerId = uLedger.LedgerId,
                    RoleId = uLedger.RoleId
                }
            );

            if (closeConnection)
            {
                conn.Close();
            }

            return ledgerId;
        }
    }
}
