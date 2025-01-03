using FamilyBudgeting.Application.DTOs;

namespace FamilyBudgeting.Application.Interfaces
{
    public interface IUserLedgerRoleQueryService
    {
        Task<IEnumerable<UserLedgerRoleDto>> GetUserLedgerRolesAsync();
        Task<UserLedgerRoleDto> GetUserLedgerRoleByTitleAsync(string title);
    }
}
