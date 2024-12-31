using System.ComponentModel.DataAnnotations;

namespace FamilyBudgeting.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
