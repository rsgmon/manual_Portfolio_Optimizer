using ModelOptimizer111314.DataAccess;
using System.Collections.ObjectModel;


namespace ModelOptimizer111314.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {       
        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            SymbolWeightsViewModel viewModel =
                new SymbolWeightsViewModel();
            this.ViewModels.Add(viewModel);
        }

    public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if(_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }

                return _viewModels;
            }
        }
    }    
}
