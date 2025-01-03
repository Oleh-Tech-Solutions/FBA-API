namespace FamilyBudgeting.Application.Interfaces
{
    public interface IUserLedgerRoleQueryService
    {
        Task<UserLedgerRoleDto?> GetUserLedgerRolesAsync();
        Task<UserLedgerRoleDto?> GetUserLedgerRoleByTitleAsync(string title);
    }
}
