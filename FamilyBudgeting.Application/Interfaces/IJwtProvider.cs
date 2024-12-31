using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Infrastructure.JwtProviders
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
