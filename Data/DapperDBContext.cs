using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Dapper_CRUD_ASP.Net_core_SQL_Server.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
