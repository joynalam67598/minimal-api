using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        //this directrly talk to sql server.
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            //looking for connection by connectionId
            //using help use to safely open and shutdown the connection in time of an occurence.
            using IDbConnection conncection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await conncection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection conncection = new SqlConnection(_config.GetConnectionString(connectionId));
            await conncection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
