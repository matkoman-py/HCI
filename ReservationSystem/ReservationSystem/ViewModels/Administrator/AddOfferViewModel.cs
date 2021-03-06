using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string Price { get; set; }
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
            if(Offer.Name == null || Offer.Description == null)
            {
                MessageBox.Show("Morate uneti sva polja!");
                return;
            }
            if (Offer.Name.Trim() == "" || Offer.Description.Trim() == "")
            {
                MessageBox.Show("Morate uneti sva polja!");
                return;
            }
            int budget;
            bool success = Int32.TryParse(Price, out budget);
            if (!success)
            {
                MessageBox.Show("Morate uneti brojevnu vrednost za cenu!");
                return;
            }
            Offer.Price = budget;
            if (Offer.IsRoom)
            {
                ViewChangeUtils.PastViews.Push(this);
                UpdateViewCommand.Execute(new AddRoomViewModel(UpdateViewCommand, Associate, Offer));
            }
            else 
            {
                Offer.Associate = Associate;
                Associate.Offers.Add(Offer);
                MessageBox.Show("Uspešno ste dodali ponudu!");
                UpdateViewCommand.Execute(ViewChangeUtils.PastViews.Pop());
            }

        }
    }
}