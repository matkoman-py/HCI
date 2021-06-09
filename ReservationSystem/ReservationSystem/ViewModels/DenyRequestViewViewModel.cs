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
    public class DenyRequestViewViewModel :  BaseViewModel
    {
        public User User { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand RequestsOverviewPendingCommand { get; set; }
        public PartyRequest Sug { get; set; }

        public string Comment { get; set; }
        public DenyRequestViewViewModel(ICommand updateViewCommand, PartyRequest sug, User user)
        {
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            UpdateViewCommand = updateViewCommand;
            Sug = sug;
            User = user;
            Comment = "";
        }

        public void RequestOverviewPending()
        {
            using(var db = new ProjectDatabase())
            {
                Suggestion s = new Suggestion();

                db.PartyRequests.Where(pr => pr.Id == Sug.Id).First().RequestState = RequestState.Rejected;
                s.PartyRequest = db.PartyRequests.Where(pr => pr.Id == Sug.Id).First();
                s.Comment = Comment;
                s.Answered = AnsweredType.Neprihvacen;
                db.Suggestions.Add(s);
                db.SaveChanges();
            }
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
    }
}
