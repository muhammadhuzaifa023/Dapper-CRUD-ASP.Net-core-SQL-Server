using Dapper;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Data;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.IGeneric;
using Dapper_CRUD_ASP.Net_core_SQL_Server.Model;
using System.Data;

namespace Dapper_CRUD_ASP.Net_core_SQL_Server.Infrastructure.Generic
{
    public class Superheroes : ISuperHero<SuperHero>
    {
        private readonly DapperDBContext _context;
        public Superheroes(DapperDBContext context)
        {

            _context = context;
            
        }
        public async Task<IEnumerable<SuperHero>> GetAllAsync()
        {
            string query = "SELECT * FROM SuperHeroes";
            using (var connectin = _context.CreateConnection())
            {
                var Superlist = await connectin.QueryAsync<SuperHero>(query);
                return Superlist.ToList();
            }

        }
        public async Task<int> CreateAsync(SuperHero SH)
        {
            int result = 0;
            string query = "Insert into SuperHeroes(Name,FirstName,LastName,Place) values (@Name,@FirstName,@LastName,@Place)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", SH.Name, DbType.String);
            parameters.Add("FirstName", SH.FirstName, DbType.String);
            parameters.Add("LastName", SH.LastName, DbType.String);
            parameters.Add("Place", SH.Place, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<string> UpdateAsync(SuperHero superHero, int id)
        {
            string response = string.Empty;
            string query = "UPDATE SuperHeroes SET Name = @Name, FirstName = @FirstName, LastName = @LastName, Place = @Place WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", superHero.Name, DbType.String);
            parameters.Add("FirstName", superHero.FirstName, DbType.String);
            parameters.Add("LastName", superHero.LastName, DbType.String);
            parameters.Add("Place", superHero.Place, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<string> DeleteAsync(int id)
        {
            string response = string.Empty;
            string query = "DELETE FROM SuperHeroes WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }

            return response;
        }


    }
}
