using Ardalis.Result;
using FamilyBudgeting.Application.Mappers;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data.Users;
using FamilyBudgeting.Infrastructure.JwtProviders;
using FamilyBudgeting.Infrastructure.Utilities;

namespace FamilyBudgeting.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserService _userService;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(IPasswordHasher passwordHasher, IUserService userService, 
            IJwtProvider jwtProvider)
        {
            _userService = userService;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<int>> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);

            var user = new User(firstName, lastName, email, password);

            int userId = await _userService.CreateUserAsync(user);

            if (userId <= 0 )
            {
                return Result.Error("We could not create User");
            }

            return Result.Success(userId);
        }

        public async Task<Result<string>> LoginAsync(string email, string password) 
        { 
            var result = await _userService.GetUserByEmailAsync(email);

            if (!result.IsSuccess)
            {
                return Result.Error(string.Join(" ", result.Errors));
            }

            bool isPasswordCorrect = _passwordHasher.VerifyPassword(
                result.Value.PasswordHash, _passwordHasher.HashPassword(password));

            return Result.Success(_jwtProvider.GenerateToken(UserMapper.ConvertDtoToDomain(result.Value)));
        }
    }
}
