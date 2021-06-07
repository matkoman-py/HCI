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
        public ICommand ToAssociatesCommand { get; set; }
        public ICommand ToFieldsOfWorkCommand { get; set; }
        public ICommand ToPartyTypesCommand { get; set; }

        public AdminPageViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToOrganizersCommand = new DelegateCommand(ToOrganizers);
            ToAssociatesCommand = new DelegateCommand(ToAssociates);
            ToFieldsOfWorkCommand = new DelegateCommand(ToFieldsOfWork);
            ToPartyTypesCommand = new DelegateCommand(ToPartyTypes);
        }

        public AdminPageViewModel(ICommand updateViewCommand, User user) : this(updateViewCommand)
        {
            this.user = user;
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
