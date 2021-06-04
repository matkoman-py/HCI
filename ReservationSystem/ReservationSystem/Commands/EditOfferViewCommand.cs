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
    public class EditOfferViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Offer offer = (Offer)parameter;
            UpdateViewCommand.Execute(new EditOfferViewModel(UpdateViewCommand, offer));
        }

        public EditOfferViewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
