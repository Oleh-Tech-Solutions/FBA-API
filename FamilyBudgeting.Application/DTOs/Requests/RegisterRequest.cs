using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Application.DTOs.Requests
{
    public class RegisterRequest
    {
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
