using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AddOfferViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand BackCommand { get; set; }
        public ICommand AddOfferCommand { get; set; }
        public Associate Associate { get; set; }
        public Offer Offer { get; set; }

        public AddOfferViewModel(ICommand updateViewCommand, Associate associate)
        {
            Offer = new Offer();
            UpdateViewCommand = updateViewCommand;
            BackCommand = new DelegateCommand(goToPastView);
            AddOfferCommand = new DelegateCommand(AddOffer);
            Associate = associate;
        }

        private void goToPastView() 
        {
            var pastViewModel = ViewChangeUtils.PastViews.Pop();
            UpdateViewCommand.Execute(pastViewModel);
        }

        private void AddOffer() 
        {
            ViewChangeUtils.PastViews.Push(this);
            
            if (Offer.IsRoom)
            {
                UpdateViewCommand.Execute(new AddRoomViewModel(UpdateViewCommand, Associate, Offer));
            }
            else 
            {
                Offer.Associate = Associate;
                Associate.Offers.Add(Offer);
                UpdateViewCommand.Execute(new AddAssociatesViewModel(UpdateViewCommand, Associate));
            }

        }
    }
}
