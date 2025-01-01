using FamilyBudgeting.Application.DTOs;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IUserLedgerRoleService
    {
        Task<UserLedgerRoleDto?> GetUserLedgerRolesAsync();
        Task<UserLedgerRoleDto?> GetUserLedgerRoleByTitleAsync(string title);
    }
}
