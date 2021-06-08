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
    public class OrganizierHomePageViewModel : BaseViewModel
    {
        public User User { get; set; }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand LogOutCommand
        {
            get; set;
        }
        public ICommand OrganizerAssociatesOverviewCommand
        {
            get;set;
        }

        public ICommand RequestsOverviewPendingCommand
        {
            get;set;
        }
        public ICommand RequestsOverviewActiveCommand
        {
            get; set;
        }
        public ICommand RequestsOverviewProcessedCommand
        {
            get; set;
        }
        public OrganizierHomePageViewModel(ICommand updateViewCommand, User user)
        {
            User = user;
            //Console.WriteLine(User.Name);
            UpdateViewCommand = updateViewCommand;
            LogOutCommand = new DelegateCommand(LogOut);
            OrganizerAssociatesOverviewCommand = new DelegateCommand(OrganizerAssociatesOverview);
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            RequestsOverviewActiveCommand = new DelegateCommand(RequestOverviewActive);
            RequestsOverviewProcessedCommand = new DelegateCommand(RequestOverviewProcessed);
        }

        public void LogOut()
        {
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
        }

        public void OrganizerAssociatesOverview()
        {
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand,User));
        }

        public void RequestOverviewPending()
        {
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
        public void RequestOverviewActive()
        {
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Active));
        }
        public void RequestOverviewProcessed()
        {
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Accepted));
        }
    }
}
