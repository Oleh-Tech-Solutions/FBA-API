using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Domain.Data.UserLedgerRoles
{
    public class UserLedgerRole
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public UserLedgerRole(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
