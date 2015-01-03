using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace ModelOptimizer111314.DataAccess
{
    [ImplementPropertyChanged]
    public partial class Weight

    {
        public decimal ActiveWeight
        {
            get { return Security_Weight - Benchmark_Weight; }
        }
    }
}
