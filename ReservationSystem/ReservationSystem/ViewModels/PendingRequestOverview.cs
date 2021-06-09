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
        public PartyRequest Sug { get; set; }
        public ICommand DenyRequestViewCommand { get; set; }
        public static ICommand CreateSuggestionViewCommand { get; set; }
        public ICommand RequestsOverviewPendingCommand { get; set; }
        public PendingRequestOverview(ICommand updateViewCommand, PartyRequest sug)
        {
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            CreateSuggestionViewCommand = new DelegateCommand(CreateSuggestionView);
            UpdateViewCommand = updateViewCommand;
            DenyRequestViewCommand = new DelegateCommand(DenyRequestView);
            Sug = sug;
            User = getUser();
        }

        public void CreateSuggestionView()
        {
            UpdateViewCommand.Execute(new CreateSuggestionViewViewModel(UpdateViewCommand, User, Sug));
        }
        public void RequestOverviewPending()
        {
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
        public void DenyRequestView()
        {
            UpdateViewCommand.Execute(new DenyRequestViewViewModel(UpdateViewCommand, Sug,User));
        }
        public User getUser()
        {
            using (var db = new ProjectDatabase())
            {

                return db.Users.Where(u => u.Id == Sug.OrganiserId).First();
            }
        }

    }

}
