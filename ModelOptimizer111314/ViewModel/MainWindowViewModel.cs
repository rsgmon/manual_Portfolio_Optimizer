using ModelOptimizer111314.DataAccess;
using System.Collections.ObjectModel;


namespace ModelOptimizer111314.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        //FURTHER DEVELOPMENT this needs to be changed to handle ADO.net
        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
           
            /*SymbolWeightsViewModel viewModel =
                new SymbolWeightsViewModel(_symbolWeightsRepository);
            this.ViewModels.Add(viewModel);*/
            
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
