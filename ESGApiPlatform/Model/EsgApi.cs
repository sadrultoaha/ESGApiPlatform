﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class EsgApi
    {

        public double? CurrentMonthDisbursement { get; set; }
        public double? Last12MonthDisbursement { get; set; }
        public int? Last12MonthBorrower { get; set; }
        public double? Last12MonthDisbursementPercentageOnFemaleBorrower { get; set; }
        public double? Last12MonthDisbursementPercentageOnMaleBorrower { get; set; }
        public double? Last12MonthAvarageDisbursementOnFemaleBorrower { get; set; }
        public double? Last12MonthAvarageDisbursementOnMaleBorrower { get; set; }
        public double? YoYAvarageDisbursementOnFemaleBorrower { get; set; }
        public double? YoYAvarageDisbursementOnMaleBorrower { get; set; }
        public double? CurrentMonthDeposit { get; set; }
        public double? Last12MonthDeposit { get; set; }
        public int? Last12MonthDepositor { get; set; }
        public double? Last12MonthDepositPercentageOnFemaleDepositor { get; set; }
        public double? Last12MonthDepositPercentageOnMaleDepositor { get; set; }
        public double? Last12MonthAvarageDepositOnFemaleDepositor { get; set; }
        public double? Last12MonthAvarageDepositOnMaleDepositor { get; set; }
        public double? YoYAvarageDepositOnFemaleDepositor { get; set; }
        public double? YoYAvarageLoanSizeOnMaleDepositor { get; set; }
        public DateTime? MonthStart { get; set; }
        public DateTime? MonthEnd { get; set; }
        public DateTime? YearStart { get; set; }
        public DateTime? YearEnd { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
