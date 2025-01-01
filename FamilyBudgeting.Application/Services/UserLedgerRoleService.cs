using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Infrastructure.Utilities;

namespace FamilyBudgeting.Application.Services
{
    public class UserLedgerRoleService : IUserLedgerRoleService
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserLedgerRoleService(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<UserLedgerRoleDto?> GetUserLedgerRolesAsync()
        {
            string query = @"
                SELECT Id, Title
                FROM UserLedgerRole
                ORDER BY Id
                ";

            QueryLogger.LogQuery(query, null);

            using (var conn = _connectionFactory.GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<UserLedgerRoleDto?>(query);
            }
        }

        public async Task<UserLedgerRoleDto?> GetUserLedgerRoleByTitleAsync(string title)
        {
            string query = @"
                SELECT Id, Title
                FROM UserLedgerRole
                WHERE Title COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @Title
                ORDER BY Id
                ";

            using (var conn = _connectionFactory.GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<UserLedgerRoleDto?>(query,
                    new
                    {
                        Title = title
                    }
                );
            }
        }
    }
}
