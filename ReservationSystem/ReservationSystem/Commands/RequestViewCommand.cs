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
    public class RequestViewCommand : ICommand
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
            using(var db = new ProjectDatabase())
            {
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Include("PartyRequest").Where(suggestion => suggestion.Id == sug.Id).First();
            }
            UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand,sug));
        }

        public RequestViewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
