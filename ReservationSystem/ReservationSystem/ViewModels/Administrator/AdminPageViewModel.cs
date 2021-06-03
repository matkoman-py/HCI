using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AdminPageViewModel : BaseViewModel
    {
        private User user;

        public ICommand UpdateViewCommand { get; set; }

        public ICommand ToOrganizersCommand { get; set; }

        public AdminPageViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToOrganizersCommand = new DelegateCommand(ToOrganizers);
        }

        public AdminPageViewModel(ICommand updateViewCommand, User user) : this(updateViewCommand)
        {
            this.user = user;
        }

        public void ToOrganizers()
        {
            UpdateViewCommand.Execute(new AdminOrganizersOverviewModel(UpdateViewCommand));
        }
    }
}
