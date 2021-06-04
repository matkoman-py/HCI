using ReservationSystem.Models;
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
            UpdateViewCommand.Execute(new EditAssociatesViewModel(UpdateViewCommand, associate));
        }

        public EditAssociateViewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
