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
    public class AcceptedRequestOverviewViewModel : BaseViewModel
    {
        public PartyRequest PartyRequest { get; set; }
        public string Name { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand SuggestionOverviewCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public AcceptedRequestOverviewViewModel(ICommand updateViewCommand, PartyRequest partyRequest)
        {
            UpdateViewCommand = updateViewCommand;
            PartyRequest = partyRequest;
            Name = getName();
            BackCommand = new DelegateCommand(Back);
            SuggestionOverviewCommand = new DelegateCommand(SuggestionOverview);
        }
        public void SuggestionOverview()
        {
            UpdateViewCommand.Execute(new SuggestionOverviewOrganizerViewModel(UpdateViewCommand, PartyRequest.Id));
        }
        public string getName()
        {
            using(var db = new ProjectDatabase())
            {
                string name;
                User user = db.Users.Where(u => u.Id == PartyRequest.CreatorId).First();
                name = user.Name;
                return name;
            }
        }
        public void Back()
        {
            using (var db = new ProjectDatabase())
            {
                Suggestion sug = db.Suggestions.Where(s => s.PartyRequestId == PartyRequest.Id).First();
                
                User user = db.Users.Where(u => u.Id == PartyRequest.OrganiserId).First();
                if(sug.Answered == AnsweredType.Prihvacen)
                {
                    UpdateViewCommand.Execute(new AcceptedSuggestionViewModel(UpdateViewCommand, user));
                }
                else {
                    UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, user, RequestState.Accepted));
                }
                
            }
        }
    }
}
