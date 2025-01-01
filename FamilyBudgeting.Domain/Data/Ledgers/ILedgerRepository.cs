namespace FamilyBudgeting.Domain.Data.Ledgers
{
    public interface ILedgerRepository
    {
        Task<int> CreateLedgerAsync(bool closeConnection = false);
    }
}
