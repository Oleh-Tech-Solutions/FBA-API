using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<int> CreateUserAsync(User user);
    }
}
