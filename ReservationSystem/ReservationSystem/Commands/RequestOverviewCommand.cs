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
    public class RequestOverviewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PartyRequest sug = (PartyRequest)parameter;
            /*using (var db = new ProjectDatabase())
            {
                sug = db.PartyRequests.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(suggestion => suggestion.Id == sug.Id).First();
            }*/
            UpdateViewCommand.Execute(new RequestOverviewViewModel(UpdateViewCommand, sug));
        }

        public RequestOverviewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
