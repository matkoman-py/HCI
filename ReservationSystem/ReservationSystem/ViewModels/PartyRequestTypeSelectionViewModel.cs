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
    public class PartyRequestTypeSelectionViewModel : BaseViewModel, IMainWindow
    {

        public User User { get; set; }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand RequestsOverviewPendingCommand
        {
            get; set;
        }
        public ICommand RequestsOverviewActiveCommand
        {
            get; set;
        }
        public ICommand RequestsOverviewProcessedCommand
        {
            get; set;
        }
        public BaseViewModel SelectedViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PartyRequestTypeSelectionViewModel(ICommand updateViewCommand, User user)
        {
            User = user;
            //Console.WriteLine(User.Name);
            UpdateViewCommand = updateViewCommand;
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            RequestsOverviewActiveCommand = new DelegateCommand(RequestOverviewActive);
            RequestsOverviewProcessedCommand = new DelegateCommand(RequestOverviewProcessed);
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
