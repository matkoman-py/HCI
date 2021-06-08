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
    public class UserHomePageViewModel : BaseViewModel, IMainWindow
    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public List<Suggestion> Suggestions { get; set; }
        public List<PartyRequest> Requests { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        
        public User User { get; set; }
        public static string SelectedId { get; set; }
        static public ICommand LogOutCommand
        {
            get; set;
        }
        static public ICommand ProfileCommand
        {
            get; set;
        }
        static public ICommand PreviousPartiesCommand
        {
            get; set;
        }
        public static ICommand RequestCreationCommand
        {
            get; set;
        }
        public static ICommand RequestViewCommand
        {
            get; set;
        }

        static public ICommand FuturePartiesCommand
        {
            get; set;
        }

        public static ICommand NewSuggestionsCommand
        {
            get; set;
        }

        public static ICommand RequestOverviewCommand
        {
            get; set;
        }

        public static ICommand PendingRequestsCommand
        {
            get; set;
        }
        
        public UserHomePageViewModel(User user)
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            LogOutCommand = new DelegateCommand(LogOut);
            ProfileCommand = new DelegateCommand(Profile);
            PendingRequestsCommand = new DelegateCommand(PendingRequests);
            NewSuggestionsCommand = new DelegateCommand(NewSuggestions);
            PreviousPartiesCommand = new DelegateCommand(PreviousParties);
            FuturePartiesCommand = new DelegateCommand(FutureParties);
            RequestViewCommand = new RequestViewCommand(UpdateViewCommand);
            RequestOverviewCommand = new RequestOverviewCommand(UpdateViewCommand);
            RequestCreationCommand = new DelegateCommand(RequestCreation);
            User = user;

            Requests = getRequests();
            _selectedViewModel = new ProfileViewModel(UpdateViewCommand, user);
        }

        public void RequestCreation()
        {
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand, User));
        }

        public void Profile()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, User));
        }
        public void FutureParties()
        {
            UpdateViewCommand.Execute(new FuturePartiesViewModel(UpdateViewCommand, User));
        }

        public void PreviousParties()
        {
            UpdateViewCommand.Execute(new PreviousPartiesViewModel(UpdateViewCommand, User));
        }

        public void NewSuggestions()
        {
            UpdateViewCommand.Execute(new NewSuggestionsViewModel(UpdateViewCommand, User));
        }

        public void PendingRequests()
        {
            UpdateViewCommand.Execute(new PendingRequestsViewModel(UpdateViewCommand, User));
        }
        
        public void LogOut()
        {
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
        }


        public List<Suggestion> getSuggestions()
        {
            // OVDE TREBA IZ DB UZETI SVE SUGGESTIONE KOJI IMAJU ID USERA KOJI JE PROSLEDJEN OVOM PROZORU
            // TO DALJE SALJES
            List<Suggestion> list = new List<Suggestion>();
            using (var db = new ProjectDatabase())
            {

                list = db.Suggestions
                        .Include("PartyRequest")
                        .Include("OrganizierTasks")
                        .Include("OrganizierTasks.Offers")
                        .Where(suggestion => suggestion.PartyRequest.CreatorId == User.Id)
                        .ToList();
                foreach(Suggestion s in list)
                {
                    Console.WriteLine(s.PartyRequest.CreatorId);
                }
            }
            return list;
        }

        public List<PartyRequest> getRequests()
        {
            List<PartyRequest> list = new List<PartyRequest>();
            using(var db = new ProjectDatabase())
            {
                list = db.PartyRequests.Where(pr => pr.CreatorId == User.Id).ToList();
            }
            return list;
        }
    }
}