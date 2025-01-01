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
            int userId = await _authService.RegisterAsync(request.FirstName, 
                request.LastName, request.Email, request.Password);

            if (userId <= 0) 
            {
                return BadRequest("Error occured during creating a user");
            }

            return Ok(userId);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);

            HttpContext.Response.Cookies.Append(AppConstants.JwtCockieName, token);

            return Ok();
        }
    }
}
