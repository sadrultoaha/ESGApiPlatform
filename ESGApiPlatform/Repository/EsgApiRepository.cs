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
