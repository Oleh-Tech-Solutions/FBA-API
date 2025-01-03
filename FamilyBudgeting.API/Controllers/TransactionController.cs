using FamilyBudgeting.Application.DTOs.Requests.Transactions;
using FamilyBudgeting.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgeting.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
        {
            int userId = GetUserIdFromToken();

            var result = await _transactionService.CreateTransactionAsync(userId, request.LedgerId, 
                request.TransactionTypeId, request.Amount, request.Date, request.Note);

            if (!result.IsSuccess)
            {
                return BadRequest(string.Join(" ", result.Errors));
            }

            return Ok();
        }
    }
}
