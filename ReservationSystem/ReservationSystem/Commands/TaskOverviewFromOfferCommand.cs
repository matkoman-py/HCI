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
    public class TaskOverviewFromOfferCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Offer sug = (Offer)parameter;
            
            OrganizierTask ot = null;
            using (var db = new ProjectDatabase())
            {
                ot = db.OrganizierTasks.Include("Offers")
                        .First();
            }
            UpdateViewCommand.Execute(new TaskOverviewViewModel(UpdateViewCommand, ot));
        }

        public TaskOverviewFromOfferCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
