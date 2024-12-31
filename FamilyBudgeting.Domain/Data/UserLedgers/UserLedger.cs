using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Domain.Data.UserLedgers
{
    public class UserLedger : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int LedgerId { get; set; }

        public UserLedger(int userId, int roleId, int ledgerId)
        {
            UserId = userId;
            RoleId = roleId;
            LedgerId = ledgerId;
        }
    }
}
