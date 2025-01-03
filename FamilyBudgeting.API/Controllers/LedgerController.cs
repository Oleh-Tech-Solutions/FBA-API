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

            var result = await _ledgerRoleService.GetUserLedgerRoleByTitleAsync("Owner");

            if (!result.IsSuccess)
            {
                return BadRequest(string.Join(" ", result.Errors));
            }

            var result2 = await _ledgerService.CreateLedgerAsync(userId, result.Value.Id);

            if (!result2.IsSuccess)
            {
                return BadRequest(string.Join(" ", result2.Errors));
            }

            return Ok(result2.Value);
        }
    }
}
