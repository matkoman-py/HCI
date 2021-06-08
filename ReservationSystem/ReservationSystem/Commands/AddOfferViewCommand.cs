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
    public class AddOfferViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private BaseViewModel pastView;
        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewChangeUtils.PastViews.Push(pastView);
            Offer offer = (Offer)parameter;
            UpdateViewCommand.Execute(new EditOfferViewModel(UpdateViewCommand, offer));
        }

        public AddOfferViewCommand(ICommand updateViewCommand, BaseViewModel baseViewModel)
        {
            pastView = baseViewModel;
            UpdateViewCommand = updateViewCommand;
        }
    }
}
