using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.ViewModels.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    class AdminHomePageViewModel : BaseViewModel, IMainWindow
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

        public User User { get; set; }
        public static string SelectedId { get; set; }
        static public ICommand LogOutCommand { get; set; }
        static public ICommand ProfileCommand { get; set; }
        static public ICommand ToOrganizersCommand { get; set; }
        static public ICommand ToAssociatesCommand { get; set; }
        static public ICommand ToFieldsOfWorkCommand { get; set; }
        static public ICommand ToPartyTypesCommand { get; set; }

        public AdminHomePageViewModel(User user)
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            LogOutCommand = new DelegateCommand(LogOut);
            ProfileCommand = new DelegateCommand(Profile);

            ToOrganizersCommand = new DelegateCommand(ToOrganizers);
            ToAssociatesCommand = new DelegateCommand(ToAssociates);
            ToFieldsOfWorkCommand = new DelegateCommand(ToFieldsOfWork);
            ToPartyTypesCommand = new DelegateCommand(ToPartyTypes);

            User = user;
            _selectedViewModel = new ProfileViewModel(UpdateViewCommand, user);
        }

        

        public void Profile()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, User));
        }

        public void LogOut()
        {
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
        }

        public void ToOrganizers()
        {
            UpdateViewCommand.Execute(new AdminOrganizersOverviewModel(UpdateViewCommand));
        }

        public void ToAssociates()
        {
            UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand));
        }
        public void ToFieldsOfWork()
        {
            UpdateViewCommand.Execute(new AdminFieldsOfWorkViewModel(UpdateViewCommand));
        }
        public void ToPartyTypes()
        {
            UpdateViewCommand.Execute(new AdminPartyTypeViewModel(UpdateViewCommand));
        }

    }
}
