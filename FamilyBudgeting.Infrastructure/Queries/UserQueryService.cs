using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Application.Interfaces;
using FamilyBudgeting.Infrastructure.Utilities;

namespace FamilyBudgeting.Infrastructure.Queries
{
    public class UserQueryService : IUserQueryService
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserQueryService(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            string query = @"
                SELECT TOP(1) Id, FirstName, LastName, Email, PasswordHash FROM [User]
                WHERE Email = @Email
                ORDER BY Id
                ";

            QueryLogger.LogQuery(query, (object)email);

            using (var conn = _connectionFactory.GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<UserDto?>(query,
                    new
                    {
                        Email = email
                    });
            }
        }
    }
}
