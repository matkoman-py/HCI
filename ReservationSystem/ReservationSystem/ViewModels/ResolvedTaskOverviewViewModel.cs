using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class ResolvedTaskOverviewViewModel : BaseViewModel
    {
        
        public ICommand UpdateViewCommand { get; set; }
        public OrganizierTask OrganizierTask { get; set; }
        public ICommand BackCommand { get; set; }
        public OfferReviewOrganizerCommand OfferReviewOrganizerCommand { get; set; }

        public static Offer SelectedOffer { get; set; }
        public static ICommand OfferReviewCommand { get; set; }
        public ResolvedTaskOverviewViewModel(ICommand updateViewCommand, OrganizierTask organizierTask)
        {
            UpdateViewCommand = updateViewCommand;
            OrganizierTask = organizierTask;
            BackCommand = new DelegateCommand(Back);
            OfferReviewOrganizerCommand = new OfferReviewOrganizerCommand(updateViewCommand);
            OfferReviewCommand = new DelegateCommand(OfferReview);
        }

        public void Back()
        {
            using (var db = new ProjectDatabase())
            {
                Suggestion sug;
                sug = db.Suggestions.Include("OrganizierTasks").Include("OrganizierTasks.Offers").Where(s => s.Id == OrganizierTask.SuggestionId).First();
                UpdateViewCommand.Execute(new SuggestionOverviewViewModel(UpdateViewCommand, sug.PartyRequestId));
            }
        }
        public void OfferReview()
        {
            Offer o;
            using (var db = new ProjectDatabase())
            {
                
                o = db.Offers.Include("Associate").Where(of => of.Id == SelectedOffer.Id).First();
            }
            UpdateViewCommand.Execute(new OfferReviewOrganizerViewModel(UpdateViewCommand, o, OrganizierTask.Id));
        }
    }
}
