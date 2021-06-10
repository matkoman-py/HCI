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
    public class TutorialViewModel : BaseViewModel, IMainWindow
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

        public string tutorialText;
        public string TutorialText
        {
            get { return tutorialText; }
            set
            {
                tutorialText = value;
                OnPropertyChanged(nameof(TutorialText));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public TutorialViewModel()
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            getStartView();

        }

        public void getStartView()
        {
            _selectedViewModel = new PendingRequestOverviewViewModel(UpdateViewCommand, false, this);
        }

    }
}
