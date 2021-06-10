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
        public User User { get; set; }
        public PendingRequestOverviewViewModel(ICommand updateViewCommand, bool flagCard)
        {
            UpdateViewCommand = updateViewCommand;
            RequestsToShow = getRequests();
            GoToNextViewCommand = new DelegateCommand(GoToNextView);
            flag = flagCard;
        }

        public PendingRequestOverviewViewModel(ICommand updateViewCommand, PartyRequest partyRequest, bool flagCard)
        {
            UpdateViewCommand = updateViewCommand;
            RequestsToShow = getRequests();
            GoToNextViewCommand = new DelegateCommand(GoToNextView);
            var prToDelete = requestsToShow.Find(pr => pr.Id == partyRequest.Id);
            requestsToShow.Remove(prToDelete);
            flag = flagCard;
        }

        public object GoToNextView(object partyRequest)
        {
            if (flag == false)
            {
                UpdateViewCommand.Execute(new PendingRequestViewModel(UpdateViewCommand, (PartyRequest)partyRequest, flag));
                flag = true;
            }
            else
            {
                UpdateViewCommand.Execute(new PendingRequestViewModel(UpdateViewCommand, (PartyRequest)partyRequest, flag));
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
