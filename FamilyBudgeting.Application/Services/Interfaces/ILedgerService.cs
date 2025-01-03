using Ardalis.Result;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface ILedgerService
    {
        Task<Result<int>> CreateLedgerAsync(int userId, int roleId);
    }
}
