using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data.Transactions;

namespace FamilyBudgeting.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<int> CreateTransactionAsync(int authorId, int ledgerId, 
            int transactionTypeId, double amount, DateTime date, string? note)
        {
            var newTransaction = new Transaction(authorId, ledgerId, transactionTypeId, 
                amount, date, note);

            return await _transactionRepository.CreateTransactionAsync(newTransaction);
        }
    }
}
