using System;
using ModelOptimizer111314.DataAccess;
using System.Collections.ObjectModel;

namespace ModelOptimizer111314.ViewModel
{
    class SymbolWeightsViewModel : ViewModelBase
    {
        BenchMarkEntities _context;

        public BenchMarkEntities Context
        {
            get { return _context; }
        }

        ObservableCollection<Weight> _databaseWeights;

        public ObservableCollection<Weight> DatabaseWeights
        {
           get { return _databaseWeights; }
        }

        public SymbolWeightsViewModel() 
        {
            _context = new BenchMarkEntities();
        }
        /* I need to use the entity framework from here 
         * in this viewmodel.*/

    }
}
