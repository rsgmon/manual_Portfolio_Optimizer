//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelOptimizer111314.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Weight
    {
        public int BenchmarkID { get; set; }
        public string Symbol { get; set; }
        public decimal Benchmark_Weight { get; set; }
        public decimal Security_Weight { get; set; }
        public string Symbol_and_BenchmarkID { get; set; }
        public bool Weight_Exists { get; set; }
    }
}
