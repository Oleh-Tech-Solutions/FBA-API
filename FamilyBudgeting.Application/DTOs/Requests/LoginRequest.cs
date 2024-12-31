using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Application.DTOs.Requests
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
