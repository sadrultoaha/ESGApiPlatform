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
        Task<EsgAggregation> GetAggregationData(int industries, int districts, int years);
        Task<EsgSDG> GetSDGData(string type);
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
        public async Task <EsgAggregation> GetAggregationData(int industries, int districts, int years)
        {
            EsgAggregation aggregationData = new EsgAggregation();
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }
                try
                {
                    aggregationData = await _esgApiRepository.GetAggregationData(conn);
                    aggregationData.AgeGroupWiseData = await _esgApiRepository.GetAgeGroupWiseData(conn);
                    aggregationData.IndustryWiseRanking = await _esgApiRepository.GetIndustryWiseRankingData(conn, industries);
                    aggregationData.DistrictWiseRanking = await _esgApiRepository.GetDistrictWiseRankingData(conn, districts);
                    aggregationData.DisbursementTrendData = await _esgApiRepository.GetDisbursementTrendData(conn, years);
                }
                catch
                {
                    return null;
                }
            }
            return aggregationData;
        }
        public async Task<EsgSDG> GetSDGData(string type)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }
                try
                {
                    return await _esgApiRepository.GetSDGData(conn, type);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
