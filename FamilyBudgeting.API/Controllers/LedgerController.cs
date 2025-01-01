using FamilyBudgeting.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FamilyBudgeting.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class LedgerController : ControllerBase
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
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }

            // Extract the user ID from the claims
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId);
            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in token.");
            }

            if (!Int32.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized("User ID is not correct in token.");
            }

            var role = await _ledgerRoleService.GetUserLedgerRoleByTitleAsync("Owner");

            int ledgerId = await _ledgerService.CreateLedgerAsync(userId, role.Id);

            return Ok(ledgerId);
        }
    }
}
