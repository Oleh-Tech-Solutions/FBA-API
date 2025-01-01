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

        public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
        {
            int userId = GetUserIdFromToken();

            int trId = await _transactionService.CreateTransactionAsync(userId, request.LedgerId, 
                request.TransactionTypeId, request.Amount, request.Date, request.Note);

            if (trId <= 0)
            {
                return BadRequest("Unexpected error occured during creatin transaction");
            }

            return Ok();
        }
    }
}
