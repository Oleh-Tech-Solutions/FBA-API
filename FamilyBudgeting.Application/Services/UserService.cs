using Dapper;
using FamilyBudgeting.Application.Configuration;
using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IUserRepository _userRepository;

        public UserService(ISqlConnectionFactory connectionFactory, IUserRepository userRepository)
        {
            _connectionFactory = connectionFactory;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            using (var conn = _connectionFactory.GetOpenConnection()) 
            {
                return await conn.QueryFirstOrDefaultAsync<UserDto>(@"
                    SELECT TOP(1) Id, FirstName, LastName, Email, PasswordHash FROM [User]
                    WHERE Email = @Email
                    ",
                    new
                    {
                        Email = email
                    });
            }
        }

        public async Task<int> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
