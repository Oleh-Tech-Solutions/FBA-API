namespace FamilyBudgeting.Domain.Data.Transactions
{
    public interface ITransactionRepository
    {
        Task<int> CreateTransactionAsync(Transaction transaction);
    }
}
