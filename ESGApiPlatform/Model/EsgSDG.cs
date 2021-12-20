using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class EsgSDG
    {
        public string Type { get; set; }
        public double? Last12MonthDisbursement { get; set; }
        public double? Last36MonthDisbursement { get; set; }
        public int? Last36MonthBorrower { get; set; }
        public double? Last36MonthAvarageDisbursement { get; set; }
        public double? YoYAvarageDisbursement { get; set; }
        public int? Last36MonthHouseholdMember { get; set; }
        public string TopIndutryOnLast12MonthDisbursement { get; set; }
        public string TopDistrictOnLast12MonthDisbursement { get; set; }
        public double? Last36MonthDisbursementPercentageOnFemaleBorrower { get; set; }
        public DateTime? YearStart { get; set; }
        public DateTime? YearEnd { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
