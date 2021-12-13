using ESGApiPlatform.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Repository
{
    public interface IEsgApiRepository
    {
        Task<EsgApiData> GetData(SqlConnection conn);
    }
    public class EsgApiRepository: IEsgApiRepository
    {
        public async Task<EsgApiData> GetData(SqlConnection conn)
        {
            EsgApiData data = new EsgApiData();

            try // Query for Aggregation table
            {
                string sql = @"select * from [Aggregation]";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        EsgAggregation model = new EsgAggregation();
                        model.CurrentMonthDisbursement =  Convert.ToDouble(dr["CurrentMonthDisbursement"] as double?);
                        model.Last12MonthDisbursement =  Convert.ToDouble(dr["Last12MonthDisbursement"] as double?);
                        model.Last12MonthBorrower = Convert.ToInt32(dr["Last12MonthBorrower"] as int?);                       
                        model.Last12MonthDisbursementPercentageOnFemaleBorrower = Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnFemaleBorrower"] as double?);                       
                        model.Last12MonthDisbursementPercentageOnMaleBorrower = Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnMaleBorrower"] as double?);                       
                        model.Last12MonthAvarageDisbursementOnFemaleBorrower = Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnFemaleBorrower"] as double?);                        
                        model.Last12MonthAvarageDisbursementOnMaleBorrower = Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnMaleBorrower"] as double?);                       
                        model.YoYAvarageDisbursementOnFemaleBorrower = Convert.ToDouble(dr["YoYAvarageDisbursementOnFemaleBorrower"] as double?);                       
                        model.YoYAvarageDisbursementOnMaleBorrower = Convert.ToDouble(dr["YoYAvarageDisbursementOnMaleBorrower"] as double?);                       
                        model.CurrentMonthDeposit = Convert.ToDouble(dr["CurrentMonthDeposit"]) as double?;                        
                        model.Last12MonthDeposit = Convert.ToDouble(dr["Last12MonthDeposit"] as double?);                       
                        model.Last12MonthDepositor = Convert.ToInt32(dr["Last12MonthDepositor"] as int?); 
                        model.Last12MonthDepositPercentageOnFemaleDepositor = Convert.ToDouble(dr["Last12MonthDepositPercentageOnFemaleDepositor"] as double?);                       
                        model.Last12MonthDepositPercentageOnMaleDepositor = Convert.ToDouble(dr["Last12MonthDepositPercentageOnMaleDepositor"] as double?);                                          
                        model.Last12MonthAvarageDepositOnFemaleDepositor = Convert.ToDouble(dr["Last12MonthAvarageDepositOnFemaleDepositor"] as double?);                       
                        model.Last12MonthAvarageDepositOnMaleDepositor = Convert.ToDouble(dr["Last12MonthAvarageDepositOnMaleDepositor"] as double?);                      
                        model.YoYAvarageDepositOnFemaleDepositor = Convert.ToDouble(dr["YoYAvarageDepositOnFemaleDepositor"] as double?); 
                        model.YoYAvarageLoanSizeOnMaleDepositor = Convert.ToDouble(dr["YoYAvarageLoanSizeOnMaleDepositor"] as double?);                      
                        model.MonthStart = Convert.ToDateTime(dr["MonthStart"] as DateTime?);                       
                        model.MonthEnd = Convert.ToDateTime(dr["MonthEnd"] as DateTime?);                     
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        data.Aggregation = model;
                    }
                    await dr.CloseAsync();
                }

            }
            catch(Exception ex)
            {
                return null;
            }
            // Query for SDG table
            try
            {
                string sql = @"select * from [SDG]";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        EsgSDG model = new EsgSDG();

                        model.Last12MonthDisbursementZeroHunger = Convert.ToDouble(dr["Last12MonthDisbursementZeroHunger"] as double?);
                        model.Last36MonthDisbursementZeroHunger = Convert.ToDouble(dr["Last36MonthDisbursementZeroHunger"] as double?);
                        model.Last36MonthBorrowerOfZeroHunger = Convert.ToInt32(dr["Last36MonthBorrowerOfZeroHunger"] as int?);
                        model.Last36MonthAvarageDisbursementOnZeroHunger = Convert.ToDouble(dr["Last36MonthAvarageDisbursementOnZeroHunger"] as double?);
                        model.YoYAvarageDisbursementOnZeroHunger = Convert.ToDouble(dr["YoYAvarageDisbursementOnZeroHunger"] as double?);
                        model.Last36MonthHouseholdMemberOfZeroHunger = Convert.ToInt32(dr["Last36MonthHouseholdMemberOfZeroHunger"] as int?);
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                        data.SDG = model;
                    }
                    await dr.CloseAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return data;
        }

    }
}
