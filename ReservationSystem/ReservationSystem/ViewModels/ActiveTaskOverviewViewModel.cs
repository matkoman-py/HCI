using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class ActiveTaskOverviewViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public OrganizierTask OrganizierTask { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SeeMoreCommand { get; set; }
        public ICommand AddOfferCommand { get; set; }
        public static ICommand OfferReviewCommand { get; set; }
        public ObservableCollection<Offer> SelectedOffers { get; set; }
        public List<Offer> AllOffers { get; set; }
        public static Offer ToGoOffer { get; set; }
        public Offer SelectedOffer { get; set; }
        public ActiveTaskOverviewViewModel(ICommand updateViewCommand, OrganizierTask organizierTask)
        {
            UpdateViewCommand = updateViewCommand;   
            OrganizierTask = organizierTask;
            SelectedOffer = null;
            BackCommand = new DelegateCommand(Back);
            SaveCommand = new DelegateCommand(Save);
            SeeMoreCommand = new DelegateCommand(SeeMore);
            AddOfferCommand = new DelegateCommand(AddOffer);
            SelectedOffers = new ObservableCollection<Offer>(OrganizierTask.Offers);
            AllOffers = getAllOffers();
            OfferReviewCommand = new DelegateCommand(OfferReview);
        }
        public void Back()
        {
            if (OrganizierTask.IsDone)
            {
                using (var db = new ProjectDatabase())
                {
                    Suggestion sug;
                    sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                    UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
                }
            }
            else
            {
                using (var db = new ProjectDatabase())
                {
                    OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                    o.Offers.Clear();
                    
                    Suggestion sug;
                    sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                    sug.Price = 0;
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
                }
            }

        }
        public void Save()
        {
            
            using (var db = new ProjectDatabase())
            {
                OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                if(o.Offers.Count == 0)
                {
                    MessageBox.Show("Morate dodati bar jednu ponudu na zadatak");
                    return;
                }
                o.IsDone = true;
                db.SaveChanges();
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
            }
            
        }
        public List<Offer> getAllOffers()
        {
            using(var db = new ProjectDatabase())
            {
                return db.Offers.Include("Associate").Include("Associate.FieldOfWork").ToList();
            }
        }
        public void SeeMore()
        {
            if(SelectedOffer == null)
            {
                MessageBox.Show("Morate selektovati ponudu!");
            }
            else
            {
                UpdateViewCommand.Execute(new OfferReviewOrganizerViewModel(UpdateViewCommand, SelectedOffer, OrganizierTask.Id));
            }
        }
        public void OfferReview()
        {
            Offer o;
            using (var db = new ProjectDatabase())
            {

                o = db.Offers.Include("Associate").Where(of => of.Id == ToGoOffer.Id).First();
            }
            UpdateViewCommand.Execute(new OfferReviewOrganizerViewModel(UpdateViewCommand, o, OrganizierTask.Id));
        }

        private void CheckIsAlreadyOffered() 
        {
            using (var db = new ProjectDatabase())
            {

                OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                foreach (Offer of in o.Offers)
                {
                    if (of.Id == SelectedOffer.Id)
                    {
                        MessageBox.Show("Ne mozete dva put dodati istu ponudu!");
                        return;
                    }
                }
            }
            if (SelectedOffers.Contains(SelectedOffer))
            {
                MessageBox.Show("Ne mozete dva put dodati istu ponudu!");
                return;
            }
        }

        public void AddRegularOffer() 
        {
            SelectedOffers.Add(SelectedOffer);
            using (var db = new ProjectDatabase())
            {
                OrganizierTask.Offers.Add(SelectedOffer);
                double price = 0;

                foreach (Offer off in OrganizierTask.Offers)
                {
                    //TODO: Odraditi proveru za prihvaceno
                    price += off.Price;
                }
                OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                Offer offer = db.Offers.Include("Associate").Include("Associate.FieldOfWork").Where(of => of.Id == SelectedOffer.Id).First();
                o.Offers.Add(offer);
                db.Suggestions.Where(suggestion => suggestion.Id == OrganizierTask.SuggestionId).First().Price += price;
                db.SaveChanges();
            }

        }

        private void GoToTableArrangmentView() 
        {
        }

        public void AddOffer()
        {
            if (SelectedOffer == null)
            {
                MessageBox.Show("Morate selektovati ponudu!");
            }
            else
            {
                CheckIsAlreadyOffered();

                if (SelectedOffer.Associate.FieldOfWork.HasRoom)
                {
                    GoToTableArrangmentView();
                }
                else 
                {
                    AddRegularOffer();
                }

            }
        }
       
    }
}
