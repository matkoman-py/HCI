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
    public class DataUpdateViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public string password { get; set; }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand ProfileCancelCommand
        {
            get; set;
        }

        public ICommand ProfileSaveCommand
        {
            get; set;
        }

        public DataUpdateViewModel(ICommand updateViewCommand, string name, string surname,string username, string email, string birthday, string password)
        {
            UpdateViewCommand = updateViewCommand;
            ProfileCancelCommand = new DelegateCommand(ProfileCancel);
            ProfileSaveCommand = new DelegateCommand(ProfileSave);
            this.name = name;
            
        }
        public void ProfileCancel()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand));
        }
        public void ProfileSave()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand));
        }
    }
}
