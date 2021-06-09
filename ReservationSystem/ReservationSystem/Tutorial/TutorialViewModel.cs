using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Tutorial.ViewModel;
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

        public TutorialViewModel(int  tutorialType)
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            getStartView(tutorialType);

        }

        public void getStartView(int tutorialType)
        {

            if (tutorialType == 0)
            {
                _selectedViewModel = new PendingRequestOverviewViewModel(UpdateViewCommand);
            }
            else
            {
               // _selectedViewModel = new ProfileViewModel(UpdateViewCommand, user);
            }

        }

    }
}
