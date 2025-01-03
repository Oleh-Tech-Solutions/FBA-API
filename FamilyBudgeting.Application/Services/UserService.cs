using Ardalis.Result;
using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Application.Interfaces;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQueryService _userQueryService;

        public UserService(IUserRepository userRepository, IUserQueryService userQueryService)
        {
            _userRepository = userRepository;
            _userQueryService = userQueryService;
        }

        public async Task<Result<UserDto>> GetUserByEmailAsync(string email)
        {
            var user = await _userQueryService.GetUserByEmailAsync(email);

            if (user == null) 
            {
                return Result.Error($"There is no user with email: {email}");
            }

            return Result.Success(user);
        }

        public async Task<Result<int>> CreateUserAsync(User user)
        {
            int userId = await _userRepository.CreateUserAsync(user);

            if (userId <= 0)
            {
                return Result.Error($"We could not create user with email {user.Email}");
            }

            return Result.Success(userId);
        }
    }
}
