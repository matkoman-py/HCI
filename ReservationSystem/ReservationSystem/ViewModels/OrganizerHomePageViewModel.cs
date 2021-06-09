using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    class OrganizerHomePageViewModel : BaseViewModel, IMainWindow
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
        static public ICommand ProfileCommand { get; set; }
        static public ICommand PartyRequestsSelectionTypeCommand { get; set; }
        static public ICommand AssociateOverviewCommand { get; set; }

        static public ICommand AcceptedSuggestionOverviewCommand { get; set; }
        public User User { get; set; }

        public OrganizerHomePageViewModel(User user)
        {
            UpdateViewCommand = new UpdateViewCommand(this);

            ProfileCommand = new DelegateCommand(Profile);
            PartyRequestsSelectionTypeCommand = new DelegateCommand(PartyRequestsSelectionType);
            AssociateOverviewCommand = new DelegateCommand(AssociateOverview);
            AcceptedSuggestionOverviewCommand = new DelegateCommand(AcceptedSuggestion);
            User = user;
            _selectedViewModel = new ProfileViewModel(UpdateViewCommand, user);
        }

        public void AcceptedSuggestion()
        {
            UpdateViewCommand.Execute(new AcceptedSuggestionViewModel(UpdateViewCommand, User));
        }
        public void Profile()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, User));
        }

        public void PartyRequestsSelectionType()
        {
            UpdateViewCommand.Execute(new PartyRequestTypeSelectionViewModel(UpdateViewCommand, User));
        }

        public void AssociateOverview()
        {
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand, User));
        }

    }
}
