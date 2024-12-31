namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(string firstName, string lastName, string email, string password);
        Task<string> LoginAsync(string email, string password);
    }
}
