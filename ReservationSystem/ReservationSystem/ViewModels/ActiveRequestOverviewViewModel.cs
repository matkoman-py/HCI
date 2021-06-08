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
    public class ActiveRequestOverviewViewModel : BaseViewModel
    {
        public PartyRequest PartyRequest { get; set; }
        public string Name { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public ICommand BackCommand { get; set; }
        public ICommand SuggestionOverviewCommand { get; set; }
        public ActiveRequestOverviewViewModel(ICommand updateViewCommand, PartyRequest partyRequest)
        {
            UpdateViewCommand = updateViewCommand;
            PartyRequest = partyRequest;
            Name = getName();
            BackCommand = new DelegateCommand(Back);
            SuggestionOverviewCommand = new DelegateCommand(SuggestionOverview);
        }

        public string getName()
        {
            using (var db = new ProjectDatabase())
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

                User user = db.Users.Where(u => u.Id == PartyRequest.CreatorId).First();
                UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, user, RequestState.Active));
            }
        }
        public void SuggestionOverview()
        {
            UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, PartyRequest.Id));
        }
    }
}
