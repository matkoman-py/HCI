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
    public class UserHomePageViewModel : BaseViewModel
    {


        public List<Suggestion> Suggestions { get; set; }
        public List<PartyRequest> Requests { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        
        public User User { get; set; }
        public static string SelectedId { get; set; }
        public ICommand LogOutCommand
        {
            get; set;
        }
        public ICommand ProfileCommand
        {
            get; set;
        }
        public ICommand RequestCreationCommand
        {
            get; set;
        }
        public static ICommand RequestViewCommand
        {
            get; set;
        }

        public static ICommand RequestOverviewCommand
        {
            get; set;
        }
        public UserHomePageViewModel(ICommand updateViewCommand, User user)
        {

            UpdateViewCommand = updateViewCommand;
            LogOutCommand = new DelegateCommand(LogOut);
            ProfileCommand = new DelegateCommand(Profile);
            RequestViewCommand = new RequestViewCommand(UpdateViewCommand);
            RequestOverviewCommand = new RequestOverviewCommand(UpdateViewCommand);
            RequestCreationCommand = new DelegateCommand(RequestCreation);
            User = user;

            //Suggestions = getSuggestions();
            Requests = getRequests();
        }

        public void RequestCreation()
        {
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand, User));
        }

        public void Profile()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, User));
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