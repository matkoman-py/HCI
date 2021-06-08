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
        public DenyRequestViewViewModel(ICommand updateViewCommand, PartyRequest sug, User user)
        {
            RequestsOverviewPendingCommand = new DelegateCommand(RequestOverviewPending);
            UpdateViewCommand = updateViewCommand;
            Sug = sug;
            User = user;
        }

        public void RequestOverviewPending()
        {
            using(var db = new ProjectDatabase())
            {
                db.PartyRequests.Where(pr => pr.Id == Sug.Id).First().RequestState = RequestState.Rejected;
                db.SaveChanges();
            }
            UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, User, RequestState.Pending));
        }
    }
}
