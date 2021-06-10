using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Tutorial.ViewModel
{
    public class DenyRequestViewViewModel : BaseViewModel
    {
        public User User { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand RejectCommand { get; set; }
        public PartyRequest Sug { get; set; }
        public string Comment { get; set; }
        public DenyRequestViewViewModel(ICommand updateViewCommand, PartyRequest sug, User user)
        {
            RejectCommand = new DelegateCommand(RequestOverviewPending);
            UpdateViewCommand = updateViewCommand;
            Sug = sug;
            User = user;
            Comment = "";
        }

        public void RequestOverviewPending()
        {

            Suggestion s = new Suggestion();

            s.Comment = Comment;
            s.Answered = AnsweredType.Neprihvacen;
            UpdateViewCommand.Execute(new PendingRequestOverviewViewModel(UpdateViewCommand, Sug, true));
        }
    }
}
