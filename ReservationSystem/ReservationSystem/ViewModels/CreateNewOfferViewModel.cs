using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class CreateNewOfferViewModel : BaseViewModel
    {
        public Associate Associate { get; set; }

        public Offer Offer { get; set; }
        public string Price { get; set; }
        public User User { get; set; }
        public ICommand UpdateViewCommand
        {
            get; set;
        }

        public static ICommand AssociateOverviewCommand
        {
            get; set;
        }

        public ICommand AddOfferCommand
        {
            get; set;
        }

        public CreateNewOfferViewModel(ICommand updateViewCommand, Associate associate, User user)
        {
            UpdateViewCommand = updateViewCommand;
            User = user;
            AssociateOverviewCommand = new DelegateCommand(AssociateOverview);
            Associate = associate;
            Offer = new Offer();
            AddOfferCommand = new DelegateCommand(AddOffer);
        }

        public void AssociateOverview()
        {
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand, User));
        }

        private void AddOffer()
        {
            if(string.IsNullOrEmpty(Offer.Name) || string.IsNullOrEmpty(Offer.Description))
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
            Associate ass;
            using(var db = new ProjectDatabase())
            {
                
                ass = db.Associates.Include("Offers").Where(a => a.Id == Associate.Id).First();
                Offer.Associate = ass;
                Offer.Price = budget;
                db.Offers.Add(Offer);
                ass.Offers.Add(Offer);
                db.SaveChanges();
            }
            
            MessageBox.Show("Uspesno ste kreirali ponudu");
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand, User));
        }
    }
}
