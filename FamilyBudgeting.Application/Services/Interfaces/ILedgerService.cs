namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface ILedgerService
    {
        Task<int> CreateLedgerAsync(int userId, int roleId);
    }
}
