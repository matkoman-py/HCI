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
    public class RequestViewViewModel : BaseViewModel
    {
        public Suggestion Suggestion { get; set; }
        public User user { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public ICommand UserHomePageCommand
        {
            get; set;
        }

        public static ICommand TaskOverviewCommand
        {
            get; set;
        }

        public RequestViewViewModel(ICommand updateViewCommand, Suggestion suggestion)
        {

            UpdateViewCommand = updateViewCommand;
            Suggestion = suggestion;
            
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            TaskOverviewCommand = new TeskOverviewCommand(UpdateViewCommand);
        }

        public void UserHomePage()
        {
            //treba da se prosledjuje id korisnika koji je u pitanju - znaci nzm kako 
            // i nesto sacuvas u bazu valjda 

            using (var db = new ProjectDatabase())
            {
                Console.WriteLine(Suggestion.PartyRequest.CreatorId);
                user = db.Users.Where(u => u.Id == Suggestion.PartyRequest.CreatorId).First();
            }
            UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand, user));
        }
    }
}
