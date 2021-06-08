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
    public class OfferReviewOrganizerCommand : ICommand
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
            //Console.WriteLine(sug.Comment);
            UpdateViewCommand.Execute(new OfferReviewOrganizerViewModel(UpdateViewCommand, sug,1));
        }

        public OfferReviewOrganizerCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
