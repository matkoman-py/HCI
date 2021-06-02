using ReservationSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class ChooseOrganisatorPageViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public ICommand RequestCreationCommand
        {
            get; set;
        }

        public ICommand UserHomePageCommand
        {
            get; set;
        }

        public ChooseOrganisatorPageViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            RequestCreationCommand = new DelegateCommand(RequestCreation);
            UserHomePageCommand = new DelegateCommand(UserHomePage);
        }

        public void UserHomePage()
        {

            UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand));
        }

        public void RequestCreation()
        {
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand));
        }
    }
}
