using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Application.Interfaces;
using FamilyBudgeting.Application.Services.Interfaces;

namespace FamilyBudgeting.Application.Services
{
    public class UserLedgerRoleService : IUserLedgerRoleService
    {
        private readonly IUserLedgerRoleQueryService _userLedgerRoleQueryService;

        public UserLedgerRoleService(IUserLedgerRoleQueryService userLedgerRoleQueryService)
        {
            _userLedgerRoleQueryService = userLedgerRoleQueryService;
        }

        public async Task<UserLedgerRoleDto?> GetUserLedgerRolesAsync()
        {
            return await _userLedgerRoleQueryService.GetUserLedgerRolesAsync();
        }

        public async Task<UserLedgerRoleDto?> GetUserLedgerRoleByTitleAsync(string title)
        {
            return await _userLedgerRoleQueryService.GetUserLedgerRoleByTitleAsync(title);
        }
    }
}
