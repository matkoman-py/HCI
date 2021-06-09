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
    public class ResolvedTaskOverviewOrganizerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OrganizierTask sug = (OrganizierTask)parameter;

            using (var db = new ProjectDatabase())
            {
                sug = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == sug.Id).First();
            }
            
            UpdateViewCommand.Execute(new ResolvedTaskOverviewViewModel(UpdateViewCommand, sug));
            
        }

        public ResolvedTaskOverviewOrganizerCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
