using FamilyBudgeting.Application.DTOs;

namespace FamilyBudgeting.Application.Interfaces
{
    public interface IUserQueryService
    {
        Task<UserDto?> GetUserByEmailAsync(string email);
    }
}
