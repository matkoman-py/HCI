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
    public class PendingRequestViewModel : BaseViewModel
    {
        private PartyRequest PartyRequest { get; set; }

        public bool First { get; set; }

        public ICommand UpdateViewCommand { get; set; }
        public ICommand GoToNexViewCommand { get; set; }
        public User User { get; set; }
        public PendingRequestViewModel(ICommand updateViewCommand, PartyRequest partyRequest, bool firstCard)
        {
            UpdateViewCommand = updateViewCommand;
            PartyRequest = partyRequest;
            First = firstCard;
        }


    }
}
