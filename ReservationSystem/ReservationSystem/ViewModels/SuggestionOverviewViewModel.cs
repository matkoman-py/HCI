using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{

    public class SuggestionOverviewViewModel : BaseViewModel
    {
        public Suggestion Suggestion { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand SendOfferCommand { get; set; }
        public TaskOverviewOrganizerCommand TaskOverviewOrganizerCommand { get; set; }
        public SuggestionOverviewViewModel(ICommand updateViewCommand, int partyRequestId)
        {
            UpdateViewCommand = updateViewCommand;
            Suggestion = getSuggestion(partyRequestId);
            BackCommand = new DelegateCommand(Back);
            SendOfferCommand = new DelegateCommand(SendOffer);
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

                PartyRequest pr = db.PartyRequests.Include("PartyType").Where(u => u.Id == Suggestion.PartyRequestId).First();
                UpdateViewCommand.Execute(new ActiveRequestOverviewViewModel(UpdateViewCommand, pr));
            }
        }
        public void SendOffer()
        {
            using (var db = new ProjectDatabase())
            {
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Include("PartyRequest").Where(s => s.Id == Suggestion.Id).First();
                foreach(OrganizierTask ot in sug.OrganizierTasks)
                {
                    if (!ot.IsDone)
                    {
                        MessageBox.Show("Niste zavrsili sve zadatke!");
                        return;
                    }
                }
                PartyRequest pr;
                pr = db.PartyRequests.Where(p => p.Id == Suggestion.PartyRequestId).First();
                pr.RequestState = RequestState.Accepted;
                sug.Answered = AnsweredType.Neobradjen;
                sug.Comment = Suggestion.Comment;
                db.SaveChanges();
                User user = db.Users.Where(u => u.Id == sug.PartyRequest.OrganiserId).First();
                UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, user, RequestState.Active));
            }
        }
    }
}
