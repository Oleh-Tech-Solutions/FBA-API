using FamilyBudgeting.Application.Services.Interfaces;
using FamilyBudgeting.Domain.Data;

namespace FamilyBudgeting.Application.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public User GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
