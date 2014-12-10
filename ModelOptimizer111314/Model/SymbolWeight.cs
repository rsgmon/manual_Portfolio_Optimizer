
namespace ModelOptimizer111314.Model
{
    class SymbolWeight
    {
        public string Symbol { get; set; }
        public decimal BenchWeight { get; set; }
        public decimal ActualWeight { get; set; }

        public decimal ActiveWeight
        {
            get { return ActualWeight - BenchWeight; }
        }

        public static SymbolWeight CreateSymbolWeight(string symbol, decimal benchWeight, decimal actualWeight)
        {
            return new SymbolWeight { Symbol = symbol};
        }
    }
}
