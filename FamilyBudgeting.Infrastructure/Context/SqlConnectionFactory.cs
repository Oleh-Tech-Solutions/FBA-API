using FamilyBudgeting.Application.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FamilyBudgeting.Infrastructure.Context
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public IDbTransaction BeginTransaction()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                GetOpenConnection();
            }

            _transaction ??= _connection.BeginTransaction();
            return _transaction;
        }

        public IDbTransaction GetCurrentTransaction()
        {
            return _transaction;
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;

            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }

            _connection = null;
        }
    }
}
