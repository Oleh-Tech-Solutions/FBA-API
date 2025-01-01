using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Application.DTOs.Requests.Transactions
{
    public class CreateTransactionRequest
    {
        [Required]
        public int LedgerId { get; set; }
        [Required]
        public int TransactionTypeId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Note { get; set; }
    }
}
