using Ardalis.Result;

namespace FamilyBudgeting.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result<int>> RegisterAsync(string firstName, string lastName, string email, string password);
        Task<Result<string>> LoginAsync(string email, string password);
    }
}
