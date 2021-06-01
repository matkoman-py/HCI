using ReservationSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class UserHomePageViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LogOutCommand
        {
            get; set;
        }
        public ICommand ProfileCommand
        {
            get; set;
        }
        public ICommand RequestCreationCommand
        {
            get; set;
        }
        public UserHomePageViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            LogOutCommand = new DelegateCommand(LogOut);
            ProfileCommand = new DelegateCommand(Profile);
            RequestCreationCommand = new DelegateCommand(RequestCreation);
        }

        public void RequestCreation()
        {
            UpdateViewCommand.Execute("RequestCreation");
        }

        public void Profile()
        {
            UpdateViewCommand.Execute("Profile");
        }

        public void LogOut()
        {
            UpdateViewCommand.Execute("Login");
        }
    }
}
