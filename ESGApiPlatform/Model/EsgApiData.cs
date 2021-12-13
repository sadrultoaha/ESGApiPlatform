using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Model
{
    public class EsgApiData
    {
        public virtual EsgAggregation Aggregation { get; set; }
        public virtual EsgSDG SDG { get; set; }

    }
}
