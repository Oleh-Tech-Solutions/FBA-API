using FamilyBudgeting.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgeting.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class LedgerController : BaseController
    {
        private readonly IUserLedgerRoleService _ledgerRoleService;
        private readonly ILedgerService _ledgerService;

        public LedgerController(IUserLedgerRoleService ledgerRoleService, ILedgerService ledgerService)
        {
            _ledgerRoleService = ledgerRoleService;
            _ledgerService = ledgerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLedger()
        {
            int userId = GetUserIdFromToken();

            var role = await _ledgerRoleService.GetUserLedgerRoleByTitleAsync("Owner");

            if (role is null)
            {
                return BadRequest("Ledger Role was not found");
            }

            int ledgerId = await _ledgerService.CreateLedgerAsync(userId, role.Id);

            return Ok(ledgerId);
        }
    }
}
