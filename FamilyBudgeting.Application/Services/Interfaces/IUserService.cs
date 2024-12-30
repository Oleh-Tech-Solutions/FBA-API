using FamilyBudgeting.Domain.Data;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmailAsync(string email);
    }
}
