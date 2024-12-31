using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateUserAsync(User user)
        {
            using (var conn = _connectionFactory.GetOpenConnection())
            {
                return await conn.ExecuteScalarAsync<int>(@"
                    INSERT INTO [USER] (FirstName, LastName, Email, PasswordHash)
                    Values (@Fname, @Lname, @Email, @PasswordHash); 
                    SELECT SCOPE_IDENTITY();
                    ",
                    new
                    {
                        Fname = user.FirstName,
                        Lname = user.LastName,
                        Email = user.Email,
                        PasswordHash = user.PasswordHash,
                    });
            }
        }
    }
}
