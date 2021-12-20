using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class DisbursementTrend
    {
        public string Year { get; set; }
        public double DisbursementAmount { get; set; }
        public int SortKey { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
