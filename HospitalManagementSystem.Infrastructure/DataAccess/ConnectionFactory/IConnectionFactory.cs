using System.Data;

namespace HospitalManagementSystem.Infrastructure.DataAccess.ConnectionFactory;

public interface IConnectionFactory
{
    IDbConnection CreateConnection();
}