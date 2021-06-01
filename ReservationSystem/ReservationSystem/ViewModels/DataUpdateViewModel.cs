using ReservationSystem.Commands;
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
        public ICommand UpdateViewCommand { get; set; }

        public ICommand ProfileCancelCommand
        {
            get; set;
        }

        public ICommand ProfileSaveCommand
        {
            get; set;
        }

        public DataUpdateViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ProfileCancelCommand = new DelegateCommand(ProfileCancel);
            ProfileSaveCommand = new DelegateCommand(ProfileSave);
        }
        public void ProfileCancel()
        {
            UpdateViewCommand.Execute("Profile");
        }
        public void ProfileSave()
        {
            UpdateViewCommand.Execute("Profile");
        }
    }
}
