using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Tutorial.ViewModel
{
    public class PendingRequestOverviewViewModel : BaseViewModel
    {

        private List<PartyRequest> requestsToShow;
        public List<PartyRequest> RequestsToShow
        {
            get { return requestsToShow; }
            set
            {
                requestsToShow = value;
                OnPropertyChanged("RequestsToShow");
            }
        }

        public bool flag;

        public ICommand UpdateViewCommand { get; set; }
        public ICommand GoToNextViewCommand { get; set; }
        public TutorialViewModel Tutorial { get; set; }
        public User User { get; set; }
        public PendingRequestOverviewViewModel(ICommand updateViewCommand, bool flagCard, TutorialViewModel TutorialWindow)
        {
            UpdateViewCommand = updateViewCommand;
            RequestsToShow = getRequests();
            GoToNextViewCommand = new DelegateCommand(GoToNextView);
            flag = flagCard;
            Tutorial = TutorialWindow;
            Tutorial.TutorialText = "Izaberite jednu od ponuda klikom na dugme 'Vidi više'.";
        }

        public PendingRequestOverviewViewModel(ICommand updateViewCommand, PartyRequest partyRequest, bool flagCard, TutorialViewModel TutorialWindow)
        {
            UpdateViewCommand = updateViewCommand;
            RequestsToShow = getRequests();
            GoToNextViewCommand = new DelegateCommand(GoToNextView);
            var prToDelete = requestsToShow.Find(pr => pr.Id == partyRequest.Id);
            requestsToShow.Remove(prToDelete);
            flag = flagCard;
            Tutorial = TutorialWindow;
            Tutorial.TutorialText = "Izaberite drugu preostalu ponudu klikom na dugme 'Vidi više'.";
        }

        public object GoToNextView(object partyRequest)
        {
            if (flag == false)
            {
                UpdateViewCommand.Execute(new PendingRequestViewModel(UpdateViewCommand, (PartyRequest)partyRequest, flag, Tutorial));
                flag = true;
            }
            else
            {
                UpdateViewCommand.Execute(new PendingRequestViewModel(UpdateViewCommand, (PartyRequest)partyRequest, flag, Tutorial));
            }
            return partyRequest;
        }

        private List<PartyRequest> getRequests()
        {
            List<PartyRequest> partyRequests = new List<PartyRequest>();
            partyRequests.Add(new PartyRequest(new PartyType(0, "Proslava mature"), 50000, "Osnovna škola 'Kizur Ištvan'", new DateTime(2021, 9, 5), 26, false, "Proslava 1", "obeležavanje 5 godina mature", RequestState.Pending, 0));
            partyRequests.Add(new PartyRequest(new PartyType(1, "Rođendan"), 50000, "Igraonica 'Larisa'", new DateTime(2021, 9, 5), 26, false, "Proslava 2", "obeležavanje 5. rođendana glavatog Mateje", RequestState.Pending, 0));
            return partyRequests;
        }


        public List<PartyRequest> getPending()
        {
            using (var db = new ProjectDatabase())
            {
                return db.PartyRequests.Include("PartyType").Where(req => req.RequestState == RequestState.Pending && req.OrganiserId == User.Id).OrderBy(requst => requst.Date).ToList();
            }
        }

    }
}
