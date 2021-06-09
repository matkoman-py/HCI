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
    public class RequestOverviewViewModel : BaseViewModel
    {
        public PartyRequest Request { get; set; }

        public List<Suggestion> Suggestion { get; set; }

        public Suggestion SelectedSuggestion { get; set; }

        public string Visibility { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand NewSuggestionsCommand { get; set; }

        public string Pending { get; set; }
        public static ICommand RequestViewCommand
        {
            get; set;
        }
        public ICommand UserHomePageCommand
        {
            get; set;
        }
        public RequestOverviewViewModel(ICommand updateViewCommand, PartyRequest suggestion)
        {

            UpdateViewCommand = updateViewCommand;
            Request = suggestion;
            RequestViewCommand = new RequestViewCommand(UpdateViewCommand);
            NewSuggestionsCommand = new DelegateCommand(NewSuggestions);
            Suggestion = getSuggestion();
            Pending = getPending();
        }
        public string getPending()
        {
            if (Request.RequestState == RequestState.Pending)
            {
                return "Hidden";
            }
            return "Visible";
        }
        public void NewSuggestions()
        {
            
            if(Pending == "Hidden")
            {
                User user;
                using (var db = new ProjectDatabase())
                {

                    user = db.Users.Where(u => u.Id == Request.CreatorId).First();
                    UpdateViewCommand.Execute(new PendingRequestsViewModel(UpdateViewCommand, user));
                    
                }
            }
            else { 
            User user;
            using (var db = new ProjectDatabase())
            {
                    Suggestion sug = db.Suggestions.Where(s => s.PartyRequestId == Request.Id).First();
                    user = db.Users.Where(u => u.Id == Request.CreatorId).First();
                    if (sug.Answered == AnsweredType.Neobradjen && sug.PartyRequest.Date.CompareTo(DateTime.Now) > 0)
                    {
                        UpdateViewCommand.Execute(new NewSuggestionsViewModel(UpdateViewCommand, user));
                    }
                    else { UpdateViewCommand.Execute(new PreviousPartiesViewModel(UpdateViewCommand, user)); }
                }
            
            }
        }

        public List<Suggestion> getSuggestion()
        {
            List<Suggestion> sug = new List<Suggestion>();
            using (var db = new ProjectDatabase())
            {

                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.PartyRequestId == Request.Id).ToList();
            }
            if (sug.Count != 0)
                Visibility = "Hidden";
            else
                Visibility = "Visible";
            return sug;
        }
    }
}
