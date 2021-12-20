using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class AgeGroupWiseData
    {
        public string AgeGroup { get; set; }
        public double Last12MonthDisbursement { get; set; }
        public double Last12MonthAvarageDisbursement { get; set; }
        public int SortKey { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
