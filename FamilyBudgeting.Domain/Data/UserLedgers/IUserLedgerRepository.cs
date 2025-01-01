namespace FamilyBudgeting.Domain.Data.UserLedgers
{
    public interface IUserLedgerRepository
    {
        Task<int> CreateUserLedgerAsync(UserLedger uLedger, bool closeConnection = false);
    }
}
