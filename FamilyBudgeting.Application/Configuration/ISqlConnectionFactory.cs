using System.Data;

namespace FamilyBudgeting.Application.Configuration
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
        IDbTransaction GetCurrentTransaction();
        IDbTransaction BeginTransaction();
    }
}
