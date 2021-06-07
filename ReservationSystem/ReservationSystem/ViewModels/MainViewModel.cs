using ReservationSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainWindow
    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel 
        {
            get { return _selectedViewModel; } 
            set { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            _selectedViewModel = new LoginViewModel(UpdateViewCommand);
            //_selectedViewModel = new AssociateOverviewViewModel(UpdateViewCommand);
        }
    }
}
