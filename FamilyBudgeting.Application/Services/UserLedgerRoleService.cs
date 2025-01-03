using Ardalis.Result;
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

        public async Task<Result<IEnumerable<UserLedgerRoleDto>>> GetUserLedgerRolesAsync()
        {
            var uLDtos = await _userLedgerRoleQueryService.GetUserLedgerRolesAsync();

            if (uLDtos is null)
            {
                return Result.Error("We encountered null value during getting User Ledger Roles");
            }

            return Result.Success(uLDtos);
        }

        public async Task<Result<UserLedgerRoleDto>> GetUserLedgerRoleByTitleAsync(string title)
        {
            var uLDto = await _userLedgerRoleQueryService.GetUserLedgerRoleByTitleAsync(title);

            if (uLDto is null)
            {
                return Result.Error($"We encountered null value during getting User Ledger Role by title {title}");
            }

            return Result.Success(uLDto);
        }
    }
}
