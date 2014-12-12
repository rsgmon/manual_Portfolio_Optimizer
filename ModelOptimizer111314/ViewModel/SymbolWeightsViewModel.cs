using System;
using System.Data.Entity;
using ModelOptimizer111314.DataAccess;
using System.Collections.ObjectModel;
using ModelOptimizer111314.Model;
using System.Windows.Input;

namespace ModelOptimizer111314.ViewModel
{
    class SymbolWeightsViewModel : ViewModelBase
    {
        //Connection to the database.
        BenchMarkEntities _context;

        RelayCommand _updateCommand;

        //Property the view will use to display.
        public ObservableCollection<Weight> Weights
        {
            get;
            private set;
        }

        public BenchMarkEntities Context
        {
            get { return _context; }
        }

        public SymbolWeightsViewModel()
        {
            _context = new BenchMarkEntities();
            _context.Weights.Load();
            this.Weights = _context.Weights.Local;
        }

        ~SymbolWeightsViewModel()
        {
            _context.Dispose();
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(param => this.UpdateCommandExecute(),
                    param => this.UpdateCommandCanExecute);
                }
                return _updateCommand;
            }
        }

        void UpdateCommandExecute()
        {
            RemoveAtTrue();
            _context.SaveChanges();
        }

        bool UpdateCommandCanExecute
        {
            get { return true; }
        }

        void RemoveAtTrue()
        {
            foreach (Weight w in _context.Weights)
            {
                if (w.Weight_Exists)
                {
                    _context.Weights.Remove(w);
                }
            }
        }
    }
}