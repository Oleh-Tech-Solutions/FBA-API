using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Domain.Data.Transactions
{
    public class Transaction : BaseEntity
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int LedgerId { get; set; }
        [Required]
        public int TransactionTypeId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Note { get; set; }

        public Transaction(int authorId, int ledgerId, int transactionTypeId, double amount, DateTime date, string? note)
        {
            AuthorId = authorId;
            LedgerId = ledgerId;
            TransactionTypeId = transactionTypeId;
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}
