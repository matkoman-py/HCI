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
    public class TaskOverviewOrganizerCommand : ICommand
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
            //UpdateViewCommand.Execute(new TaskOverviewViewModel(UpdateViewCommand, sug));
            if (sug.IsDone)
            {
                Console.WriteLine("Idi na zavrsenog");
                UpdateViewCommand.Execute(new ResolvedTaskOverviewViewModel(UpdateViewCommand, sug));
            }
            else
            {
                Console.WriteLine("idi na aktivnog");
                UpdateViewCommand.Execute(new ActiveTaskOverviewViewModel(UpdateViewCommand, sug));
            }
        }

        public TaskOverviewOrganizerCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
