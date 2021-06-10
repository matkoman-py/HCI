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
    public class PendingRequestViewModel : BaseViewModel
    {
        public bool First { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand RejectCommand { get; set; }
        public ICommand AcceptCommand { get; set; }
        public PartyRequest PartyRequest{ get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public PendingRequestViewModel(ICommand updateViewCommand, PartyRequest partyRequest, bool firstCard)
        {
            UpdateViewCommand = updateViewCommand;
            PartyRequest = partyRequest;
            First = firstCard;
            AcceptCommand = new DelegateCommand(Accept);
            RejectCommand = new DelegateCommand(Reject);
            Name = "Ana";
        }

        private void Accept() 
        {
            UpdateViewCommand.Execute(new CreateSuggestionViewModel(UpdateViewCommand, new User(), PartyRequest));
        }

        private void Reject() 
        {
            UpdateViewCommand.Execute(new DenyRequestViewViewModel(UpdateViewCommand, PartyRequest, new User()));
        }


    }
}
