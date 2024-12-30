using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Domain.Data
{
    public class UserLedgerRoles
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public UserLedgerRoles(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
