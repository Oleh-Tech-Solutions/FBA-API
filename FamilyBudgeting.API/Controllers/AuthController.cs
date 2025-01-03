using FamilyBudgeting.Application.DTOs.Requests.Auths;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgeting.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request.FirstName, 
                request.LastName, request.Email, request.Password);

            if (!result.IsSuccess) 
            {
                return BadRequest(string.Join(" ", result.Errors));
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request.Email, request.Password);

            if (!result.IsSuccess)
            {
                return BadRequest(string.Join(" ", result.Errors));
            }

            HttpContext.Response.Cookies.Append(AppConstants.JwtCockieName, result.Value);

            return Ok();
        }
    }
}
