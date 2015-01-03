using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelOptimizer111314.DataAccess
{
    public partial class Weight
    {
        public decimal ActiveWeight
        {
            get { return Security_Weight - Benchmark_Weight; }
        }
    }
}
