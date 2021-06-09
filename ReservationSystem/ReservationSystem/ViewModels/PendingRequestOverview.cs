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
    public class PendingRequestOverview : BaseViewModel
    {
        public User User { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public PartyRequest PartyRequest { get; set; }
        public ICommand DenyRequestViewCommand { get; set; }
        public ICommand CreateSuggestionViewCommand { get; set; }
        public ICommand RequestsOverviewPendingCommand { get; set; }
        public PendingRequestOverview(ICommand updateViewCommand, PartyRequest sug)
        {
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            CreateSuggestionViewCommand = new DelegateCommand(CreateSuggestionView);
            UpdateViewCommand = updateViewCommand;
            DenyRequestViewCommand = new DelegateCommand(DenyRequestView);
            PartyRequest = sug;
            User = getUser();
        }

        public void CreateSuggestionView()
        {
            UpdateViewCommand.Execute(new CreateSuggestionViewViewModel(UpdateViewCommand, User, PartyRequest));
        }
        public void RequestOverviewPending()
        {
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
        public void DenyRequestView()
        {
            UpdateViewCommand.Execute(new DenyRequestViewViewModel(UpdateViewCommand, PartyRequest, User));
        }
        public User getUser()
        {
            using (var db = new ProjectDatabase())
            {

                return db.Users.Where(u => u.Id == PartyRequest.OrganiserId).First();
            }
        }

    }

}
