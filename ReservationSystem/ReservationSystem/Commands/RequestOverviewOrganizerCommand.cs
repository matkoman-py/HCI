using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Commands
{
    public class RequestOverviewOrganizerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Suggestion sug = (Suggestion)parameter;
            PartyRequest pr;
            using (var db = new ProjectDatabase())
            {
                pr = db.PartyRequests.Include("PartyType").Where(suggestion => suggestion.Id == sug.PartyRequestId).First();
            }
            UpdateViewCommand.Execute(new AcceptedRequestOverviewViewModel(UpdateViewCommand, pr));
        }

        public RequestOverviewOrganizerCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
