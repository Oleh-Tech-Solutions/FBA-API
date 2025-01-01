using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FamilyBudgeting.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int GetUserIdFromToken()
        {
            // Extract the user ID claim
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId);
            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("User ID not found in token.");
            }

            // Validate the claim value as an integer
            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new UnauthorizedAccessException("User ID in token is invalid.");
            }

            return userId;
        }
    }
}
