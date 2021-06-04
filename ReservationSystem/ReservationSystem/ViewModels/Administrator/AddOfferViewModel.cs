using ReservationSystem.Commands;
using ReservationSystem.Models;
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
            BackCommand = new DelegateCommand(()
                => UpdateViewCommand.Execute(new AddAssociatesViewModel(updateViewCommand, Associate)));
            AddOfferCommand = new DelegateCommand(AddOffer);
            Associate = associate;
        }

        private void AddOffer() 
        {
            Offer.Associate = Associate;
            Associate.Offers.Add(Offer);
            UpdateViewCommand.Execute(new AddAssociatesViewModel(UpdateViewCommand, Associate));
        }
    }
}
