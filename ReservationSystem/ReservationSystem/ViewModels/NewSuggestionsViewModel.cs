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
    class NewSuggestionsViewModel : BaseViewModel
    {

        public List<Suggestion> Suggestions { get; set; }

        private List<Suggestion> suggestionsToShow;
        public List<Suggestion> SuggestionsToShow
        {
            get { return suggestionsToShow; }
            set
            {
                suggestionsToShow = value;
                OnPropertyChanged("SuggestionsToShow");
            }
        }

        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = value;
                OnPropertyChanged("PageIndex");
                NextPageCommand.RaiseCanExecuteChanged();
                PreviousPageCommand.RaiseCanExecuteChanged();
            }
        }
        private int suggestionsLength { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand PreviousPageCommand { get; set; }
        public RequestOverviewCommand RequestOverviewCommand { get; set; }
        public User User { get; set; }

        public string Visibility { get; set; }

        public NewSuggestionsViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            User = user;
            Suggestions = getSugesstions();
            suggestionsLength = Suggestions.Count();
            NextPageCommand = new DelegateCommand(CanGetNextPage, NextPage);
            PreviousPageCommand = new DelegateCommand(CanGetPreviousPage, PreviousPage);
            PageIndex = 0;
            InitialPage();
            RequestOverviewCommand = new RequestOverviewCommand(UpdateViewCommand);
        }

        public void InitialPage()
        {
            int amount = (suggestionsLength >= 3) ? 3 : suggestionsLength;
            if (suggestionsLength == 0)
            {
                Visibility = "Visible";
            }
            else
            {
                Visibility = "Hidden";
            }
            SuggestionsToShow = Suggestions.GetRange(0, amount);
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
            SuggestionsToShow = Suggestions.GetRange(start, 3);
        }

        public Boolean CanGetNextPage()
        {
            int start = (PageIndex + 1) * 3;
            if (suggestionsLength <= start)
            {
                return false;
            }
            return true;
        }

        public void NextPage()
        {
            PageIndex++;
            int start = PageIndex * 3;
            int amount = (suggestionsLength >= start + 3) ? 3 : 3 - ((start + 3) - suggestionsLength);
            SuggestionsToShow = Suggestions.GetRange(start, amount);
        }

        private List<Suggestion> getSugesstions()
        {
            using (var db = new ProjectDatabase())
            {
                return db.Suggestions.Include("PartyRequest").Where(suggestion => suggestion.PartyRequest.CreatorId == User.Id && suggestion.Answered == AnsweredType.Neobradjen && suggestion.PartyRequest.Date.CompareTo(DateTime.Now) > 0).OrderBy(suggestion => suggestion.PartyRequest.Date).ToList();
            }
        }

    }
}
