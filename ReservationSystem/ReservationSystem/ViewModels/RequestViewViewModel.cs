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
    public class RequestViewViewModel : BaseViewModel
    {
        public Suggestion Suggestion { get; set; }

        public PartyRequest Request { get; set; }
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

        public static ICommand RequestOverviewCommand
        {
            get; set;
        }
        public static ICommand GiveAnswerCommand
        {
            get; set;
        }
        public RequestViewViewModel(ICommand updateViewCommand, Suggestion suggestion)
        {

            UpdateViewCommand = updateViewCommand;
            Suggestion = suggestion;
            using(var db = new ProjectDatabase())
            {
                Request = db.PartyRequests.Where(r => r.Id == suggestion.PartyRequestId).First();
            }
            RequestOverviewCommand = new RequestOverviewCommand(UpdateViewCommand);
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            TaskOverviewCommand = new TeskOverviewCommand(UpdateViewCommand);
            GiveAnswerCommand = new DelegateCommand(GiveAnswer);
        }

        public void UserHomePage()
        {
            //treba da se prosledjuje id korisnika koji je u pitanju - znaci nzm kako 
            // i nesto sacuvas u bazu valjda 

            using (var db = new ProjectDatabase())
            {
                user = db.Users.Where(u => u.Id == Suggestion.PartyRequest.CreatorId).First();
            }
            UpdateViewCommand.Execute(new UserHomePageViewModel(user));
        }

        public void GiveAnswer()
        {
            if (Suggestion.Answered == AnsweredType.Odbijen || Suggestion.Answered == AnsweredType.Prihvacen)
            {
                MessageBox.Show("Na predlog je vec odgovoreno!");
            }
            else
            {
                AnsweredType state = AnsweredType.Prihvacen;
                foreach(OrganizierTask ot in Suggestion.OrganizierTasks)
                {
                    if(ot.UserApproval == UserApproval.Odbijen)
                    {
                        state = AnsweredType.Odbijen;
                    }
                    if(ot.UserApproval == UserApproval.Neobradjen)
                    {
                        MessageBox.Show("Niste odgovorili na sve zadatke!");
                        return;
                    }
                }
                User user;
                using (var db = new ProjectDatabase())
                {
                    Suggestion sug;
                    sug = db.Suggestions.Where(s => s.Id == Suggestion.Id).First();
                    sug.Answered = state;
                    user = db.Users.Where(u => u.Id == Request.CreatorId).First();
                    db.SaveChanges();
                }
                UpdateViewCommand.Execute(new NewSuggestionsViewModel(UpdateViewCommand, user));
            }
        }
    }
}
