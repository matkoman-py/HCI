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

    public class SuggestionOverviewViewModel : BaseViewModel
    {
        public Suggestion Suggestion { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public TaskOverviewOrganizerCommand TaskOverviewOrganizerCommand { get; set; }
        public SuggestionOverviewViewModel(ICommand updateViewCommand, int partyRequestId)
        {
            UpdateViewCommand = updateViewCommand;
            Suggestion = getSuggestion(partyRequestId);
            BackCommand = new DelegateCommand(Back);
            TaskOverviewOrganizerCommand = new TaskOverviewOrganizerCommand(UpdateViewCommand);
        }

        public Suggestion getSuggestion(int partyRequestId)
        {
            using(var db = new ProjectDatabase())
            {
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.PartyRequestId == partyRequestId).First();
                return sug;
            }
        }
        public void Back()
        {
            using (var db = new ProjectDatabase())
            {

                PartyRequest pr = db.PartyRequests.Where(u => u.Id == Suggestion.PartyRequestId).First();
                UpdateViewCommand.Execute(new ActiveRequestOverviewViewModel(UpdateViewCommand, pr));
            }
        }
    }
}
