using FamilyBudgeting.Application.DTOs.Requests;
using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgeting.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly HttpContext _httpContext;

        public AuthController(IAuthService authService, HttpContext httpContext)
        {
            _authService = authService;
            _httpContext = httpContext;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var token = await _authService.Login(request.Email, request.Password);

            _httpContext.Response.Cookies.Append(JwtConstants.CockieName, token);

            return Ok(token);
        }
    }
}
