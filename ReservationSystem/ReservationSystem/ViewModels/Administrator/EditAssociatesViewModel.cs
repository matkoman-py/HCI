using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class EditAssociatesViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand EditAssociatesCommand { get; set; }
        public DelegateCommand AddOfferCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditOfferCommand { get; set; }
        public Associate Associate { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public EditAssociatesViewModel(ICommand updateViewCommand)
        {
            Setup(updateViewCommand);
            Associate = new Associate();
        }

        public EditAssociatesViewModel(ICommand updateViewCommand, Associate associate)
        {
            Setup(updateViewCommand);
            Associate = associate;
            Associate.FieldOfWork = FieldOfWorkOptions.Find(field => field.Id == Associate.FieldOfWorkId);
        }

        private void Setup(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            using (var db = new ProjectDatabase())
            {
                FieldOfWorkOptions = db.FieldsOfWork.ToList();
            }
            EditAssociatesCommand = new DelegateCommand(UpdateAssociates);
            AddOfferCommand = new DelegateCommand(GoToAddOffer);
            DeleteCommand = new DelegateCommand(Delete);
            EditOfferCommand = new DelegateCommand(EditOffer);
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand)));
        }

        public void GoToAddOffer()
        {
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new AddOfferViewModel(UpdateViewCommand, Associate));
        }

        private void UpdateAssociates()
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    foreach (var associateOffer in Associate.Offers) 
                    {
                        if (associateOffer.Id == 0)
                        {
                            db.Offers.Add(associateOffer);
                        }
                        else 
                        {
                            associateOffer.Associate = null;
                            associateOffer.AssociateId = Associate.Id;
                            db.Offers.Attach(associateOffer);
                        }
                    }
                    db.FieldsOfWork.Attach(Associate.FieldOfWork);
                    db.Entry(Associate).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Can't update associate!");
                }
            }
        }

        private Object Delete(Object offer)
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    var offerToDelete = (Offer)offer;
                    offerToDelete = db.Offers.Where(offerTemp => offerTemp.Id == offerToDelete.Id).FirstOrDefault();
                    db.Offers.Remove(offerToDelete);
                    db.SaveChanges();
                    Associate.Offers.Remove(Associate.Offers.Where(offerTemp => offerTemp.Id == offerToDelete.Id).First());
                    Associate.Offers = new List<Offer>(Associate.Offers);
                }
                catch
                {
                    Console.WriteLine("Can't delete field of work!");
                }
            }
            return this;
        }

        private Object EditOffer(Object offer)
        {
            var sentOffer = (Offer)offer;
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new EditOfferViewModel(UpdateViewCommand, sentOffer, "Edit"));
            return sentOffer;
        }

    }
}
