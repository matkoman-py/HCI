using ReservationSystem.Commands;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Tutorial
{
    class TutorialViewModel : BaseViewModel, IMainWindow
    {

        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public TutorialViewModel(Type currentWidnowType)
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            getStartView(currentWidnowType);

        }

        public void getStartView(Type currentWindowType)
        {



        }

    }
}
