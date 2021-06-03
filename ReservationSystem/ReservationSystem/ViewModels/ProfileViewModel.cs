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
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string password { get; set; }

        public ICommand UpdateViewCommand { get; set; }
        public ICommand UserHomePageCommand
        {
            get; set;
        }
        public ICommand DataUpdateCommand
        {
            get; set;
        }
        
        public ProfileViewModel(ICommand updateViewCommand,string name,string surname,string username,string email,DateTime birthday,string password)
        {
            UpdateViewCommand = updateViewCommand;
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            DataUpdateCommand = new DelegateCommand(DataUpdate);
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
            this.email = email;
            this.birthday = birthday;
        }


        public void UserHomePage()
        {
            UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand));
        }

        public void DataUpdate()
        {
           UpdateViewCommand.Execute(new DataUpdateViewModel(UpdateViewCommand, name, surname, username, email, birthday, password));
        }
    }
}
