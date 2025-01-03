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

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            return await _userQueryService.GetUserByEmailAsync(email);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
