using Ardalis.Result;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data.Ledgers;
using FamilyBudgeting.Domain.Data.UserLedgers;

namespace FamilyBudgeting.Application.Services
{
    public class LedgerService : ILedgerService
    {
        private readonly ILedgerRepository _ledgerRepository;
        private readonly IUserLedgerRepository _userLedgerRepository;

        public LedgerService(ILedgerRepository ledgerRepository, IUserLedgerRepository userLedgerRepository)
        {
            _ledgerRepository = ledgerRepository;
            _userLedgerRepository = userLedgerRepository;
        }

        public async Task<Result<int>> CreateLedgerAsync(int userId, int roleId)
        {
            
            int ledgerId = await _ledgerRepository.CreateLedgerAsync();

            if (ledgerId <= 0)
            {
                return Result.Error("We could not create Ledger");
            }

            var userLedger = new UserLedger(userId, roleId, ledgerId);

            int userLedgerId = await _userLedgerRepository.CreateUserLedgerAsync(userLedger);

            if (userLedgerId <= 0)
            {
                return Result.Error("We could not create User-Ledger. Ledger was not created either");
            }

            return Result.Success(userLedgerId);
        }
    }
}
