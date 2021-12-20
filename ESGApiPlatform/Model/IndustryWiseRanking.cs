using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class IndustryWiseRanking
    {
        public string IndustryName { get; set; }
        public double Last12MonthDisbursement { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
