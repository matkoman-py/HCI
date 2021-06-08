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
    public class OfferReviewCommand : ICommand
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
            Offer o;
            using(var db = new ProjectDatabase())
            {
                o = db.Offers.Include("Associate").Where(of => of.Id == sug.Id).First();
            }
            UpdateViewCommand.Execute(new OfferReviewPageViewModel(UpdateViewCommand, o,1));
        }

        public OfferReviewCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
