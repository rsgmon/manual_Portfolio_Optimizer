using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelOptimizer111314.DataAccess;
using ModelOptimizer111314.ViewModel;
using System.Linq;

namespace ModelOptimizerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (BenchMarkEntities _test = new BenchMarkEntities())
            {
                Assert.IsInstanceOfType(_test, typeof(BenchMarkEntities));
            }
        }

        [TestMethod]
        public void ContextWithStringConstructor()
        {
            BenchMarkEntities _test = new BenchMarkEntities();
            foreach (var Weight in _test.Weights)
            {
                Assert.AreEqual<int>(001, Weight.BenchmarkID);
            }
            _test.Dispose();
        }

        [TestMethod]
        public void WeightAppears()
        {
            BenchMarkEntities _test = new BenchMarkEntities();
            _test.Weights.Add(new Weight()
            {
                BenchmarkID = 001,
                Symbol = "VB",
                Benchmark_Weight = 0.0344M,
                Security_Weight = 0.0344M,
                Weight_Exists = false
            });
            foreach (var Weight in _test.Weights)
            {
                Assert.AreEqual<int>(001, Weight.BenchmarkID);
            }
            _test.Dispose();
        }

        [TestMethod]
        public void VerifyRowCount()
        {
            int x = 0;
            BenchMarkEntities _test = new BenchMarkEntities();
            foreach (Weight w in _test.Weights)
            {
                x++;
            }

            Assert.AreEqual(4, x);
        }

        [TestMethod]
        public void VerifyAdditionalRow()
        {
            int x = 0;
            using (BenchMarkEntities _test = new BenchMarkEntities())
            {
                _test.Weights.Add(new Weight()
                {
                    BenchmarkID = 001,
                    Symbol = "VB",
                    Benchmark_Weight = 0.0344M,
                    Security_Weight = 0.0344M,
                    Weight_Exists = false
                });
                _test.SaveChanges();

                foreach (Weight w in _test.Weights)
                {
                    x++;
                }
                Assert.AreEqual(5, x);
                Weight result = _test.Weights.Where(w => w.Symbol == "VB").FirstOrDefault();
                _test.Weights.Remove(result);
                _test.SaveChanges();
            }
        }
        /*Addtional tests for SymbolWeightsViewModel
         1) Does the connection to the database exist.
         2) What is the type of the data collection returned.
         3) Are there the correct number of records.*/

        [TestMethod]
        public void SymbolWeightsViewModelHasBenchmarkEntities()
        {
            SymbolWeightsViewModel _test = new SymbolWeightsViewModel();
            Assert.IsInstanceOfType(_test.Context, typeof(BenchMarkEntities));
        }

        [TestMethod]
        public void SymbolWeightsViewModelCanAccessBenchmarkEntityTypes()
        {
            SymbolWeightsViewModel _test = new SymbolWeightsViewModel();
            Assert.IsInstanceOfType(_test.Context.Weights,
                typeof(System.Data.Entity.DbSet<ModelOptimizer111314.DataAccess.Weight>));
        }

        [TestMethod]
        public void SymbolWeightsViewModelWeightsPropertyHasData()
        {
            int x = 0;
            SymbolWeightsViewModel _test = new SymbolWeightsViewModel();
            foreach (Weight w in _test.Weights)
            {
                x++;
            }
            Assert.AreEqual(4, x);
        }

        [TestMethod]
        public void SymbolWeightsViewModelWeight_ExistsIsFalse()
        {
            SymbolWeightsViewModel _test = new SymbolWeightsViewModel();
            Weight result = _test.Weights.Where(w => w.Symbol == "VB").FirstOrDefault();
            Assert.IsFalse(result.Weight_Exists);
            _test.Dispose();
        }
    }
}
