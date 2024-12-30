using FamilyBudgeting.Domain.Data;

namespace FamilyBudgeting.Infrastructure.JwtProviders
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
