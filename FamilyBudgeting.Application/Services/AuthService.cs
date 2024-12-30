using FamilyBudgeting.Application.Services.Interfaces;
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

        public async Task<string> Login(string email, string password) 
        { 
            var user = await _userService.GetUserByEmailAsync(email);

            bool isPasswordCorrect = _passwordHasher.VerifyPassword(
                user.PasswordHash, _passwordHasher.HashPassword(password));

            return _jwtProvider.GenerateToken(user);
        }
    }
}
