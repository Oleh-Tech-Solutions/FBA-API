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

        public async Task<int> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(password);

            var user = new User(firstName, lastName, email, password);

            return await _userService.CreateUserAsync(user);
        }

        public async Task<string> LoginAsync(string email, string password) 
        { 
            var user = await _userService.GetUserByEmailAsync(email);

            if (user is null)
            {
                throw new Exception($"User with email {email} not found");
            }

            bool isPasswordCorrect = _passwordHasher.VerifyPassword(
                user.PasswordHash, _passwordHasher.HashPassword(password));

            return _jwtProvider.GenerateToken(UserMapper.ConvertDtoToDomain(user));
        }
    }
}
