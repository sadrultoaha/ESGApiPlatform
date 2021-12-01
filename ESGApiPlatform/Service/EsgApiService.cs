using ESGApiPlatform.Model;
using ESGApiPlatform.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Service
{
    public interface IEsgApiService
    {
        Task<EsgApi> GetData();
    }

    public class EsgApiService: IEsgApiService
    {
        private readonly IConfiguration _config;
        private readonly IEsgApiRepository _esgApiRepository;
        public EsgApiService(IConfiguration config, IEsgApiRepository esgApiRepository)
        {
            _config = config;
            _esgApiRepository = esgApiRepository;

        }
        public async Task <EsgApi> GetData()
        {
            using(SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }
                try
                {
                    return await _esgApiRepository.GetData(conn);
                }
                catch
                {
                    return null;
                }
            }
        } 
    }
}
