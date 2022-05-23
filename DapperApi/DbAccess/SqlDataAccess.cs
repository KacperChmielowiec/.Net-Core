using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
namespace Api_mini.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration configuration;

        public SqlDataAccess(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parametrs, string connectionId = "Default")
        {
            using (IDbConnection conn = new SqlConnection(configuration.GetConnectionString(connectionId)))

                return await conn.QueryAsync<T>(procedure, parametrs, commandType: CommandType.StoredProcedure);
        }
        public async Task SaveData<U>(string procedure, U parametrs, string connectionId = "Default")
        {
            using (IDbConnection conn = new SqlConnection(configuration.GetConnectionString(connectionId)))
            {
                await conn.ExecuteAsync(procedure, parametrs, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
