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
    public class ProfileViewModel : BaseViewModel
    {
        public User User { get; set; }

        public ICommand UpdateViewCommand { get; set; }
        public ICommand UserHomePageCommand
        {
            get; set;
        }
        public ICommand DataUpdateCommand
        {
            get; set;
        }
        
        public ProfileViewModel(ICommand updateViewCommand,User user)
        {
            UpdateViewCommand = updateViewCommand;
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            DataUpdateCommand = new DelegateCommand(DataUpdate);
            User = user;
        }


        public void UserHomePage()
        {
            UpdateViewCommand.Execute(new UserHomePageViewModel(User));
        }

        public void DataUpdate()
        {
           UpdateViewCommand.Execute(new DataUpdateViewModel(UpdateViewCommand, User));
        }
    }
}
