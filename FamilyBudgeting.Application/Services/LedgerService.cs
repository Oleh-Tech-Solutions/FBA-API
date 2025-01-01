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
            _userLedgerRepository = userLedgerRepository;
            _userLedgerRepository = userLedgerRepository;
        }

        public async Task CreateLedger(int userId)
        {
            int ledgerId = await _ledgerRepository.CreateLedgerAsync();

            if (ledgerId <= 0)
            {
                throw new Exception("Unexpected error during creating Ledger");
            }

            var userLedger = new UserLedger(userId, 1, ledgerId);

            int userLedgerId = await _userLedgerRepository.CreateUserLedgerAsync(userLedger);

            if (userLedgerId <= 0)
            {
                throw new Exception("Unexpected error during creating User-Ledger");
            }
        }
    }
}
