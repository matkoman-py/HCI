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
    class RequestsOverviewViewModel : BaseViewModel
    {
        public List<PartyRequest> Requests { get; set; }

        

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

        private int pageIndex;
        public int PageIndex {
            get { return pageIndex; }
            set {
                pageIndex = value;
                OnPropertyChanged("PageIndex");
                NextPageCommand.RaiseCanExecuteChanged();
                PreviousPageCommand.RaiseCanExecuteChanged();
            } 
        }
        private int requestsLength { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public static DelegateCommand NextPageCommand { get; set; }
        public static DelegateCommand PreviousPageCommand { get; set; }

        public MoreInfoCommand MoreInfoCommand { get; set; }
        public User User { get; set; }
        public static RequestState RequestState { get; set; }
        public RequestsOverviewViewModel(ICommand updateViewCommand, User user, RequestState requestState)
        {
            UpdateViewCommand = updateViewCommand;
            User = user;
            RequestState = requestState;
            Requests = getRequests();
            requestsLength = Requests.Count();
            NextPageCommand = new DelegateCommand(CanGetNextPage, NextPage);
            PreviousPageCommand = new DelegateCommand(CanGetPreviousPage, PreviousPage);
            BackCommand = new DelegateCommand(Back);
            MoreInfoCommand = new MoreInfoCommand(UpdateViewCommand);
            PageIndex = 0;
            InitialPage();
        }

        public void InitialPage() 
        {
            int amount = (requestsLength >= 3) ? 3 : requestsLength;
            RequestsToShow = Requests.GetRange(0, amount);
        }

        public Boolean CanGetPreviousPage()
        {
            if (PageIndex == 0)
            {
                return false;
            }
            return true;
        }

        public void PreviousPage() 
        {
            PageIndex--;
            int start = PageIndex * 3;
            RequestsToShow = Requests.GetRange(start, 3);
        }

        public Boolean CanGetNextPage() 
        {
            int start = (PageIndex + 1) * 3;
            if (requestsLength <= start)
            {
                return false;
            }
            return true;
        }

        public void NextPage() 
        {
            PageIndex++;
            int start = PageIndex * 3;
            int amount = (requestsLength >= start+3) ? 3 : 3 - ((start + 3) - requestsLength);
            RequestsToShow = Requests.GetRange(start, amount);
        }

        private List<PartyRequest> getRequests() 
        {
            if(RequestState == RequestState.Accepted)
            {
                Console.WriteLine("Nabavi obradjene");
                return getProcessed();
                
            }else if(RequestState == RequestState.Pending)
            {
                Console.WriteLine("Nabavi neobradjene");
                return getPending();
            }
            else
            {
                Console.WriteLine("Nabavi aktivne");
                return getActive();
            }
            
        }
        public void Back()
        {
            UpdateViewCommand.Execute(new PartyRequestTypeSelectionViewModel(UpdateViewCommand, User));
        }

        public List<PartyRequest> getProcessed()
        {
            List<PartyRequest> list = new List<PartyRequest>();
            using (var db = new ProjectDatabase())
            {
                List<Suggestion> listSug = db.Suggestions.Include("PartyRequest").Include("PartyRequest.PartyType").ToList();
                foreach(Suggestion sug in listSug)
                {
                    if((sug.PartyRequest.RequestState == RequestState.Accepted || sug.PartyRequest.RequestState == RequestState.Rejected) && sug.PartyRequest.OrganiserId == User.Id && (sug.Answered == AnsweredType.Neprihvacen || sug.Answered == AnsweredType.Neobradjen))
                    {
                        list.Add(sug.PartyRequest);
                    }
                }
                //db.PartyRequests.Include("PartyType").Where(req => (req.RequestState == RequestState.Accepted || req.RequestState == RequestState.Rejected) && req.OrganiserId == User.Id).OrderBy(requst => requst.Date).ToList();
                return list;
            }
        }

        public List<PartyRequest> getActive()
        {
            using (var db = new ProjectDatabase())
            {
                return db.PartyRequests.Include("PartyType").Where(req => req.RequestState == RequestState.Active && req.OrganiserId == User.Id).OrderBy(requst => requst.Date).ToList();
            }
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
