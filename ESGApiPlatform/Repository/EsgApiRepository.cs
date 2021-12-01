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
        Task<EsgApi> GetData(SqlConnection conn);
    }
    public class EsgApiRepository: IEsgApiRepository
    {
        public async Task<EsgApi> GetData(SqlConnection conn)
        {
            EsgApi model = new EsgApi(); 
            try
            {
                string sql = @"select * from [esg]";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
                        model.CurrentMonthDisbursement = (float) Convert.ToDouble(dr["CurrentMonthDisbursement"] as float?);
                        model.Last12MonthDisbursement = (float)Convert.ToDouble(dr["Last12MonthDisbursement"] as float?);
                        model.Last12MonthBorrower = Convert.ToInt32(dr["Last12MonthBorrower"] as int?);                       
                        model.Last12MonthDisbursementPercentageOnFemaleBorrower = (float)Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnFemaleBorrower"] as float?);                       
                        model.Last12MonthDisbursementPercentageOnMaleBorrower = (float)Convert.ToDouble(dr["Last12MonthDisbursementPercentageOnMaleBorrower"] as float?);                       
                        model.Last12MonthAvarageDisbursementOnFemaleBorrower = (float)Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnFemaleBorrower"] as float?);                        
                        model.Last12MonthAvarageDisbursementOnMaleBorrower = (float)Convert.ToDouble(dr["Last12MonthAvarageDisbursementOnMaleBorrower"] as float?);                       
                        model.YoYAvarageDisbursementOnFemaleBorrower = (float)Convert.ToDouble(dr["YoYAvarageDisbursementOnFemaleBorrower"] as float?);                       
                        model.YoYAvarageDisbursementOnMaleBorrower = (float)Convert.ToDouble(dr["YoYAvarageDisbursementOnMaleBorrower"] as float?);                       
                        model.CurrentMonthDeposit = (float)Convert.ToDouble(dr["CurrentMonthDeposit"]) as float?;                        
                        model.Last12MonthDeposit = (float)Convert.ToDouble(dr["Last12MonthDeposit"] as float?);                       
                        model.Last12MonthDepositor = Convert.ToInt32(dr["Last12MonthDepositor"] as int?); 
                        model.Last12MonthDepositPercentageOnFemaleDepositor = (float)Convert.ToDouble(dr["Last12MonthDepositPercentageOnFemaleDepositor"] as float?);                       
                        model.Last12MonthDepositPercentageOnMaleDepositor = (float)Convert.ToDouble(dr["Last12MonthDepositPercentageOnMaleDepositor"] as float?);                                          
                        model.Last12MonthAvarageDepositOnFemaleDepositor = (float)Convert.ToDouble(dr["Last12MonthAvarageDepositOnFemaleDepositor"] as float?);                       
                        model.Last12MonthAvarageDepositOnMaleDepositor = (float)Convert.ToDouble(dr["Last12MonthAvarageDepositOnMaleDepositor"] as float?);                      
                        model.YoYAvarageDepositOnFemaleDepositor = (float)Convert.ToDouble(dr["YoYAvarageDepositOnFemaleDepositor"] as float?); 
                        model.YoYAvarageLoanSizeOnMaleDepositor = (float)Convert.ToDouble(dr["YoYAvarageLoanSizeOnMaleDepositor"] as float?);                      
                        model.MonthStart = Convert.ToDateTime(dr["MonthStart"] as DateTime?);                       
                        model.MonthEnd = Convert.ToDateTime(dr["MonthEnd"] as DateTime?);                     
                        model.YearStart = Convert.ToDateTime(dr["YearStart"] as DateTime?);
                        model.YearEnd = Convert.ToDateTime(dr["YearEnd"] as DateTime?);
                        model.CreatedAt = Convert.ToDateTime(dr["CreatedAt"] as DateTime?);

                    }
                    await dr.CloseAsync();
                }

            }
            catch(Exception ex)
            {
                return null;
            }

            return model;
        }
    }
}
