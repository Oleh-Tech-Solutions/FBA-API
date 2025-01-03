using Ardalis.Result;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Result<int>> CreateTransactionAsync(int authorId, int ledgerId,
            int transactionTypeId, double amount, DateTime date, string? note);
    }
}
