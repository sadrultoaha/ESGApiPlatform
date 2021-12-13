using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class EsgSDG
    {
        public double? Last12MonthDisbursementZeroHunger { get; set; }
        public double? Last36MonthDisbursementZeroHunger { get; set; }
        public int? Last36MonthBorrowerOfZeroHunger { get; set; }
        public double? Last36MonthAvarageDisbursementOnZeroHunger { get; set; }
        public double? YoYAvarageDisbursementOnZeroHunger { get; set; }
        public int? Last36MonthHouseholdMemberOfZeroHunger { get; set; }
        public DateTime? YearStart { get; set; }
        public DateTime? YearEnd { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
