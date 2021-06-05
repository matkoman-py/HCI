﻿using ReservationSystem.Commands;
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
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand PreviousPageCommand { get; set; }
        public User User { get; set; }

        public RequestsOverviewViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            User = user;
            Requests = getRequests();
            requestsLength = Requests.Count();
            NextPageCommand = new DelegateCommand(CanGetNextPage, NextPage);
            PreviousPageCommand = new DelegateCommand(CanGetPreviousPage, PreviousPage);
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
            if (requestsLength < start)
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
            using (var db = new ProjectDatabase()) 
            {
                return db.PartyRequests.OrderBy(requst => requst.Date).ToList();
            }
        }
    }
}
