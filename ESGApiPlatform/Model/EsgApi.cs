using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class EsgApi
    {

        public float? CurrentMonthDisbursement { get; set; }
        public float? Last12MonthDisbursement { get; set; }
        public int? Last12MonthBorrower { get; set; }
        public float? Last12MonthDisbursementPercentageOnFemaleBorrower { get; set; }
        public float? Last12MonthDisbursementPercentageOnMaleBorrower { get; set; }
        public float? Last12MonthAvarageDisbursementOnFemaleBorrower { get; set; }
        public float? Last12MonthAvarageDisbursementOnMaleBorrower { get; set; }
        public float? YoYAvarageDisbursementOnFemaleBorrower { get; set; }
        public float? YoYAvarageDisbursementOnMaleBorrower { get; set; }
        public float? CurrentMonthDeposit { get; set; }
        public float? Last12MonthDeposit { get; set; }
        public int? Last12MonthDepositor { get; set; }
        public float? Last12MonthDepositPercentageOnFemaleDepositor { get; set; }
        public float? Last12MonthDepositPercentageOnMaleDepositor { get; set; }
        public float? Last12MonthAvarageDepositOnFemaleDepositor { get; set; }
        public float? Last12MonthAvarageDepositOnMaleDepositor { get; set; }
        public float? YoYAvarageDepositOnFemaleDepositor { get; set; }
        public float? YoYAvarageLoanSizeOnMaleDepositor { get; set; }
        public DateTime? MonthStart { get; set; }
        public DateTime? MonthEnd { get; set; }
        public DateTime? YearStart { get; set; }
        public DateTime? YearEnd { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
