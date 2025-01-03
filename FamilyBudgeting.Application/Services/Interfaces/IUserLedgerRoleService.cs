using Ardalis.Result;
using FamilyBudgeting.Application.DTOs;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IUserLedgerRoleService
    {
        Task<Result<IEnumerable<UserLedgerRoleDto>>> GetUserLedgerRolesAsync();
        Task<Result<UserLedgerRoleDto>> GetUserLedgerRoleByTitleAsync(string title);
    }
}
