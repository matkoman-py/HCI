using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
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

        public ICommand SearchCommand { get; set; }
        public static ICommand OfferReviewCommand { get; set; }
        public ObservableCollection<Offer> SelectedOffers { get; set; }
        private List<Offer> allOffers { get; set; }
        public List<Offer> AllOffers
        {
            get { return allOffers; }
            set
            {
                allOffers = value;
                OnPropertyChanged("AllOffers");
            }
        }
        public static Offer ToGoOffer { get; set; }

        public string SearchParam { get; set; }
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
            SearchCommand = new DelegateCommand(Search);
        }
        public void Search()
        {
            List<Offer> wanted = new List<Offer>();
            List<Offer> all = getAllOffers();
            foreach(Offer o in all)
            {
                if(o.Name.Contains(SearchParam) || o.Description.Contains(SearchParam) || o.Associate.Name.Contains(SearchParam))
                {
                    wanted.Add(o);
                }
            }
            AllOffers = wanted;
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
                if (o.Offers.Count == 0)
                {
                    MessageBox.Show("Morate dodati bar jednu ponudu na zadatak!");
                    return;
                }
                o.IsDone = true;
                db.SaveChanges();
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                MessageBox.Show("Uspešno ste završili zadatak!");
                UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
            }

        }
        public List<Offer> getAllOffers()
        {
            using (var db = new ProjectDatabase())
            {
                return db.Offers.Include("Associate").Include("Associate.FieldOfWork").ToList();
            }
        }
        public void SeeMore()
        {
            if (SelectedOffer == null)
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

        private bool CheckIsAlreadyOffered()
        {
            using (var db = new ProjectDatabase())
            {

                OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                foreach (Offer of in o.Offers)
                {
                    if (of.Id == SelectedOffer.Id)
                    {
                        MessageBox.Show("Ne možete dva put dodati istu ponudu!");
                        return true;
                    }
                }
            }
            if (SelectedOffers.Contains(SelectedOffer))
            {
                MessageBox.Show("Ne možete dva put dodati istu ponudu!");
                return true;
            }
            return false;
        }

        public void AddRegularOffer()
        {
            SelectedOffers.Add(SelectedOffer);
            using (var db = new ProjectDatabase())
            {
                OrganizierTask.Offers.Add(SelectedOffer);
                
                OrganizierTask o = db.OrganizierTasks.Include("Offers").Where(ot => ot.Id == OrganizierTask.Id).First();
                Offer offer = db.Offers.Include("Associate").Include("Associate.FieldOfWork").Where(of => of.Id == SelectedOffer.Id).First();
                o.Offers.Add(offer);
                
                db.SaveChanges();
            }

        }

        private void GoToTableArrangmentView()
        {
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new TableArrangementViewModel(UpdateViewCommand, SelectedOffer, OrganizierTask));
        }

        public void AddOffer()
        {
            if (SelectedOffer == null)
            {
                MessageBox.Show("Morate selektovati ponudu!");
            }
            else
            {

                if (CheckIsAlreadyOffered()) return;

                if (SelectedOffer.Associate.FieldOfWork.HasRoom)
                {
                    GoToTableArrangmentView();
                }
                else
                {
                    AddRegularOffer();
                    MessageBox.Show("Dodali ste ponudu.");
                }

            }
        }

    }
}
