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
    public class RequesCreationViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand UserHomePageCommand
        {
            get; set;
        }

        public ICommand ChooseOrganisatorPageCommand
        {
            get; set;
        }

        public RequesCreationViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            ChooseOrganisatorPageCommand = new DelegateCommand(ChooseOrganisatorPage);
        }
        public void UserHomePage()
        {
            UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand,new User()));
        }

        public void ChooseOrganisatorPage()
        {
            UpdateViewCommand.Execute(new ChooseOrganisatorPageViewModel(UpdateViewCommand));
        }
    }
}
