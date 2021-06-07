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

        public ICommand SeeMoreCommand { get; set; }
        public ICommand AddOfferCommand { get; set; }
        public ObservableCollection<Offer> SelectedOffers { get; set; }
        public List<Offer> AllOffers { get; set; }

        public Offer SelectedOffer { get; set; }
        public ActiveTaskOverviewViewModel(ICommand updateViewCommand, OrganizierTask organizierTask)
        {
            UpdateViewCommand = updateViewCommand;   
            OrganizierTask = organizierTask;
            SelectedOffer = null;
            BackCommand = new DelegateCommand(Back);
            SeeMoreCommand = new DelegateCommand(SeeMore);
            AddOfferCommand = new DelegateCommand(AddOffer);
            SelectedOffers = new ObservableCollection<Offer>(OrganizierTask.Offers);
            AllOffers = getAllOffers();
        }
        public void Back()
        {
            using(var db = new ProjectDatabase())
            {
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
            }
        }
        public List<Offer> getAllOffers()
        {
            using(var db = new ProjectDatabase())
            {
                return db.Offers.Include("Associate").ToList();
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
        public void AddOffer()
        {
            if (SelectedOffer == null)
            {
                MessageBox.Show("Morate selektovati ponudu!");
            }
            else
            {
                if( SelectedOffers.Contains(SelectedOffer)){
                    MessageBox.Show("Ne mozete dva put dodati istu ponudu!");
                    return;
                }
          
                SelectedOffers.Add(SelectedOffer);
                using(var db = new ProjectDatabase())
                {
                    OrganizierTask.Offers.Add(SelectedOffer);
                    db.SaveChanges();
                }
                
            }
        }
    }
}
