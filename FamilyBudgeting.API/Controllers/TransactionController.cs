using FamilyBudgeting.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgeting.API.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
