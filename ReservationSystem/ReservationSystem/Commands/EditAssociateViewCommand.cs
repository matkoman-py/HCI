using ReservationSystem.Models;
using ReservationSystem.Utils;
using ReservationSystem.ViewModels;
using ReservationSystem.ViewModels.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Commands
{
    class EditAssociateViewCommand : ICommand
    {
        public ICommand UpdateViewCommand { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Associate associate = (Associate)parameter;
            using (var db = new ProjectDatabase())
            {
                associate = db.Associates
                    .Include("FieldOfWork")
                    .Include("Offers")
                    .Where(a => a.Id == associate.Id)
                    .FirstOrDefault();
            }
            UpdateViewCommand.Execute(new EditAssociatesViewModel(UpdateViewCommand, associate));
        }

        public EditAssociateViewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
