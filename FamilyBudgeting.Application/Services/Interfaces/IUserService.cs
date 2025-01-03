using Ardalis.Result;
using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetUserByEmailAsync(string email);
        Task<Result<int>> CreateUserAsync(User user);
    }
}
