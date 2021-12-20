using ESGApiPlatform.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Repository
{
    public interface IEsgApiRepository
    {
        Task<EsgAggregation> GetAggregationData(SqlConnection conn);
        Task<EsgSDG> GetSDGData(SqlConnection conn, string type);
        Task<List<DisbursementTrend>> GetDisbursementTrendData(SqlConnection conn, int years = 5);
        Task<List<DistrictWiseRanking>> GetDistrictWiseRankingData(SqlConnection conn, int districts = 3);
        Task<List<IndustryWiseRanking>> GetIndustryWiseRankingData(SqlConnection conn, int industries = 3);
        Task<List<AgeGroupWiseData>> GetAgeGroupWiseData(SqlConnection conn);

    }
    public class EsgApiRepository : IEsgApiRepository
    {
        public async Task<EsgAggregation> GetAggregationData(SqlConnection conn)
        {
            EsgAggregation model = new EsgAggregation();

            try
            {
                string sql = @"select 
                                    IsNull([CurrentMonthDisbursement],0 ) as [CurrentMonthDisbursement],
                                    IsNull([Last12MonthDisbursement],0 ) as [Last12MonthDisbursement],
                                    IsNull([Last12MonthBorrower],0 ) as [Last12MonthBorrower],
                                    IsNull([Last12MonthDisbursementPercentageOnFemaleBorrower],0 ) as [Last12MonthDisbursementPercentageOnFemaleBorrower],
                                    IsNull([Last12MonthDisbursementPercentageOnMaleBorrower],0 ) as [Last12MonthDisbursementPercentageOnMaleBorrower],
                                    IsNull([Last12MonthAvarageDisbursementOnFemaleBorrower],0 ) as [Last12MonthAvarageDisbursementOnFemaleBorrower],
                                    IsNull([Last12MonthAvarageDisbursementOnMaleBorrower],0 ) as [Last12MonthAvarageDisbursementOnMaleBorrower],
                                    IsNull([YoYAvarageDisbursementOnFemaleBorrower],0 ) as [YoYAvarageDisbursementOnFemaleBorrower],
                                    IsNull([YoYAvarageDisbursementOnMaleBorrower],0 ) as [YoYAvarageDisbursementOnMaleBorrower],
                                    IsNull([CurrentMonthDeposit],0 ) as [CurrentMonthDeposit],
                                    IsNull([Last12MonthDeposit],0 ) as [Last12MonthDeposit],
                                    IsNull([Last12MonthDepositPercentageOnFemaleDepositor],0 ) as [Last12MonthDepositPercentageOnFemaleDepositor],
                                    IsNull([Last12MonthDepositPercentageOnMaleDepositor],0 ) as [Last12MonthDepositPercentageOnMaleDepositor],
                                    IsNull([Last12MonthAvarageDepositOnFemaleDepositor],0 ) as [Last12MonthAvarageDepositOnFemaleDepositor],
                                    IsNull([Last12MonthAvarageDepositOnMaleDepositor],0 ) as [Last12MonthAvarageDepositOnMaleDepositor],
                                    IsNull([YoYAvarageDepositOnFemaleDepositor],0 ) as [YoYAvarageDepositOnFemaleDepositor],
                                    IsNull([YoYAvarageDepositOnMaleDepositor],0 ) as [YoYAvarageDepositOnMaleDepositor],
                                    IsNull([Last12MonthLargestLoanGivenToWomen],0 ) as [Last12MonthLargestLoanGivenToWomen],
                                    IsNull([Last12MonthLargestLoanGivenToMen],0 ) as [Last12MonthLargestLoanGivenToMen],
                                    [MonthStart],
                                    [MonthEnd],
                                    [YearStart],
                                    [YearEnd],
                                    [CreatedAt] 
                              from [Aggregation]";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        model.CurrentMonthDisbursement = Convert.ToDouble(dr["CurrentMonthDisbursement"] as double?);
                        model.Last12MonthDisbursement = Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.Last12MonthBorrower = Convert.ToInt32(dr["Last12MonthBorrower"] as int?);
                        model.Last12MonthDisbursementPercentageOnFemaleBorrower = Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnFemaleBorrower"] as double?);
                        model.Last12MonthDisbursementPercentageOnMaleBorrower = Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnMaleBorrower"] as double?);
                        model.Last12MonthAvarageDisbursementOnFemaleBorrower = Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnFemaleBorrower"] as double?);
                        model.Last12MonthAvarageDisbursementOnMaleBorrower = Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnMaleBorrower"] as double?);
                        model.YoYAvarageDisbursementOnFemaleBorrower = Convert.ToDouble(dr["YoYAvarageDisbursementOnFemaleBorrower"] as double?);
                        model.YoYAvarageDisbursementOnMaleBorrower = Convert.ToDouble(dr["YoYAvarageDisbursementOnMaleBorrower"] as double?);
                        model.CurrentMonthDeposit = Convert.ToDouble(dr["CurrentMonthDeposit"]) as double?;
                        model.Last12MonthDeposit = Convert.ToDouble(dr["Last12MonthDeposit"] as double?);
                        model.Last12MonthDepositPercentageOnFemaleDepositor = Convert.ToDouble(dr["Last12MonthDepositPercentageOnFemaleDepositor"] as double?);
                        model.Last12MonthDepositPercentageOnMaleDepositor = Convert.ToDouble(dr["Last12MonthDepositPercentageOnMaleDepositor"] as double?);
                        model.Last12MonthAvarageDepositOnFemaleDepositor = Convert.ToDouble(dr["Last12MonthAvarageDepositOnFemaleDepositor"] as double?);
                        model.Last12MonthAvarageDepositOnMaleDepositor = Convert.ToDouble(dr["Last12MonthAvarageDepositOnMaleDepositor"] as double?);
                        model.YoYAvarageDepositOnFemaleDepositor = Convert.ToDouble(dr["YoYAvarageDepositOnFemaleDepositor"] as double?);
                        model.YoYAvarageDepositOnMaleDepositor = Convert.ToDouble(dr["YoYAvarageDepositOnMaleDepositor"] as double?);
                        model.Last12MonthLargestLoanGivenToWomen = Convert.ToDouble(dr["Last12MonthLargestLoanGivenToWomen"] as double?);
                        model.Last12MonthLargestLoanGivenToMen = Convert.ToDouble(dr["Last12MonthLargestLoanGivenToMen"] as double?);
                        model.MonthStart = Convert.ToDateTime(dr["MonthStart"] as DateTime?);
                        model.MonthEnd = Convert.ToDateTime(dr["MonthEnd"] as DateTime?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return model;
        }
        public async Task<EsgSDG> GetSDGData(SqlConnection conn, string type)
        {
            EsgSDG model = new EsgSDG();

            try
            {
                string sql = @"Select [Type] 
                              ,IsNull([Last12MonthDisbursement],0) As Last12MonthDisbursement
                              ,IsNull([Last36MonthDisbursement],0) As Last36MonthDisbursement
                              ,IsNull([Last36MonthBorrower],0) As Last36MonthBorrower
                              ,IsNull([Last36MonthAvarageDisbursement],0) As Last36MonthAvarageDisbursement
                              ,IsNull([YoYAvarageDisbursement],0) As YoYAvarageDisbursement
                              ,IsNull([Last36MonthHouseholdMember],0) As Last36MonthHouseholdMember
                              ,IsNull([TopIndutryOnLast12MonthDisbursement],'') As TopIndutryOnLast12MonthDisbursement
                              ,IsNull([TopDistrictOnLast12MonthDisbursement],'') As TopDistrictOnLast12MonthDisbursement
                              ,IsNull([Last36MonthDisbursementPercentageOnFemaleBorrower],0) As Last36MonthDisbursementPercentageOnFemaleBorrower
                              ,[YearStart],[YearEnd]
                              ,[CreatedAt] From [SDG] Where [Type] = @type";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@type", Value = type, SqlDbType = SqlDbType.NVarChar });
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        model.Type = Convert.ToString(dr["Type"]);
                        model.Last12MonthDisbursement = Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.Last36MonthDisbursement = Convert.ToDouble(dr["Last36MonthDisbursement"] as double?);
                        model.Last36MonthBorrower = Convert.ToInt32(dr["Last36MonthBorrower"] as int?);
                        model.Last36MonthAvarageDisbursement = Convert.ToDouble(dr["Last36MonthAvarageDisbursement"] as double?);
                        model.YoYAvarageDisbursement = Convert.ToDouble(dr["YoYAvarageDisbursement"] as double?);
                        model.Last36MonthHouseholdMember = Convert.ToInt32(dr["Last36MonthHouseholdMember"] as int?);
                        model.TopIndutryOnLast12MonthDisbursement = Convert.ToString(dr["TopIndutryOnLast12MonthDisbursement"]);
                        model.TopDistrictOnLast12MonthDisbursement = Convert.ToString(dr["TopDistrictOnLast12MonthDisbursement"]);
                        model.Last36MonthDisbursementPercentageOnFemaleBorrower = Convert.ToDouble(dr["Last36MonthDisbursementPercentageOnFemaleBorrower"] as double?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return model;
        }

        public async Task<List<DisbursementTrend>> GetDisbursementTrendData(SqlConnection conn, int years)
        {
            List<DisbursementTrend> list = new List<DisbursementTrend>();

            try
            {
                string sql = @"SELECT TOP (" + years.ToString() + @")
                                   IsNull([Year], '') As [Year]
                                  ,IsNull([DisbursementAmount], 0) As [DisbursementAmount]
                                  ,IsNull([SortKey], 0) As [SortKey]
                                  ,[YearStart]
                                  ,[YearEnd]
                                  ,[CreatedAt]
                              FROM [MicrofinESGDB].[dbo].[DisbursementTrend]
                              ORDER BY [SortKey] ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        DisbursementTrend model = new DisbursementTrend();
                        model.Year = Convert.ToString(dr["Year"]);
                        model.DisbursementAmount = Convert.ToDouble(dr["DisbursementAmount"] as double?);
                        model.SortKey = Convert.ToInt32(dr["SortKey"] as int?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        list.Add(model);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return list;
        }

        public async Task<List<DistrictWiseRanking>> GetDistrictWiseRankingData(SqlConnection conn, int districts)
        {
            List<DistrictWiseRanking> list = new List<DistrictWiseRanking>();

            try
            {
                string sql = @"SELECT TOP (" + districts.ToString() + @")
                                   	   IsNull([DistrictName], '') As [DistrictName]
                                      ,IsNull([Last12MonthDisbursement], 0) As [Last12MonthDisbursement]
                                      ,[YearStart]
                                      ,[YearEnd]
                                      ,[CreatedAt]
                                  FROM [MicrofinESGDB].[dbo].[RankingDistrict]
                                  ORDER BY [Last12MonthDisbursement] DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        DistrictWiseRanking model = new DistrictWiseRanking();
                        model.DistrictName = Convert.ToString(dr["DistrictName"]);
                        model.Last12MonthDisbursement = Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        list.Add(model);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return list;
        }

        public async Task<List<IndustryWiseRanking>> GetIndustryWiseRankingData(SqlConnection conn, int industries)
        {
            List<IndustryWiseRanking> list = new List<IndustryWiseRanking>();

            try
            {
                string sql = @"SELECT TOP (" + industries.ToString() + @")
                                     IsNull([IndustryName], '') As [IndustryName]
                                    ,IsNull([Last12MonthDisbursement], 0) As [Last12MonthDisbursement]
                                    ,[YearStart]
                                    ,[YearEnd]
                                    ,[CreatedAt]
                                FROM [MicrofinESGDB].[dbo].[RankingIndustry]
                                ORDER BY [Last12MonthDisbursement] DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        IndustryWiseRanking model = new IndustryWiseRanking();
                        model.IndustryName = Convert.ToString(dr["IndustryName"]);
                        model.Last12MonthDisbursement = Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        list.Add(model);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return list;
        }

        public async Task<List<AgeGroupWiseData>> GetAgeGroupWiseData(SqlConnection conn)
        {
            List<AgeGroupWiseData> list = new List<AgeGroupWiseData>();

            try
            {
                string sql = @"SELECT
                                 IsNull([AgeGroup], '') As [AgeGroup]
                                ,IsNull([Last12MonthDisbursement], 0) As [Last12MonthDisbursement]
                                ,IsNull([Last12MonthAvarageDisbursement], 0) As [Last12MonthAvarageDisbursement]
                                ,IsNull([SortKey], 0) As [SortKey]
                                ,[YearStart]
                                ,[YearEnd]
                                ,[CreatedAt]
                            FROM [MicrofinESGDB].[dbo].[AgeGroup]
                            ORDER BY [SortKey] ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        AgeGroupWiseData model = new AgeGroupWiseData();
                        model.AgeGroup = Convert.ToString(dr["AgeGroup"]);
                        model.Last12MonthDisbursement = Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.Last12MonthAvarageDisbursement = Convert.ToDouble(dr["Last12MonthAvarageDisbursement"] as double?);
                        model.SortKey = Convert.ToInt32(dr["SortKey"] as int?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        list.Add(model);
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return list;
        }
    }
}
