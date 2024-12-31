namespace FamilyBudgeting.Domain.Data.Users
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
    }
}
