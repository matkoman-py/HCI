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
        public ICommand UpdateViewCommand
        {
            get; set;
        }

        public ICommand AssociateOverviewCommand
        {
            get; set;
        }

        public ICommand AddOfferCommand
        {
            get; set;
        }

        public CreateNewOfferViewModel(ICommand updateViewCommand, Associate associate)
        {
            UpdateViewCommand = updateViewCommand;
            AssociateOverviewCommand = new DelegateCommand(AssociateOverview);
            Associate = associate;
            Offer = new Offer();
            AddOfferCommand = new DelegateCommand(AddOffer);
        }

        public void AssociateOverview()
        {
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand));
        }

        private void AddOffer()
        {
            //NZM STA URADITI OVDE SKONTATI SUTRA Zajebava organizier task
            Associate ass;
            using(var db = new ProjectDatabase())
            {
                ass = db.Associates.Include("Offers").Where(a => a.Id == Associate.Id).First();
                Offer.Associate = ass;
                //db.Offers.Add(Offer);
                ass.Offers.Add(Offer);
                db.SaveChanges();
            }
            
            MessageBox.Show("Uspesno ste kreirali ponudu");
            UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand));
        }
    }
}
