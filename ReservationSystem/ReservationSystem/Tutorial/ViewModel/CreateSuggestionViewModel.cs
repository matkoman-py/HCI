using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.Tutorial.ViewModel
{
    class CreateSuggestionViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public static ICommand AcceptPendingRequestCommand { get; set; }
        public static ICommand CreateTaskCommand { get; set; }
        public List<OrganizierTask> OrganizierTasks { get; set; }
        public PartyRequest Sug { get; set; }
        public Suggestion Suggestion { get; set; }
        public User User { get; set; }
        public ICommand PendingRequestOverviewCommand { get; set; }
        public static bool FirstStep { get; set; }
        public TutorialViewModel Tutorial { get; set; }

        public CreateSuggestionViewModel(ICommand updateViewCommand, User user, PartyRequest sug, TutorialViewModel TutorialWindow)
        {
            Sug = sug;
            User = user;
            Suggestion = new Suggestion();
            OrganizierTasks = new List<OrganizierTask>();
            UpdateViewCommand = updateViewCommand;
            AcceptPendingRequestCommand = new DelegateCommand(AcceptPendingRequest);
            CreateTaskCommand = new DelegateCommand(CreateTask);
            Tutorial = TutorialWindow;
            Tutorial.TutorialText = "Kliknite na dugme 'Novi zadatak' kako bi kreirali novi zadatak.";
        }

        public CreateSuggestionViewModel(ICommand updateViewCommand, User user, PartyRequest sug, Suggestion suggestion, TutorialViewModel TutorialWindow)
        {
            Sug = sug;
            User = user;
            Suggestion = suggestion;
            OrganizierTasks = Suggestion.OrganizierTasks;
            UpdateViewCommand = updateViewCommand;
            AcceptPendingRequestCommand = new DelegateCommand(AcceptPendingRequest);
            CreateTaskCommand = new DelegateCommand(CreateTask);
            Tutorial = TutorialWindow;
            Tutorial.TutorialText = "Nakon unosa komentara, kliknite na dugme 'Prihvati zahtev'.";
        }

        public void CreateTask()
        {
            FirstStep = true;
            UpdateViewCommand.Execute(new CreateTaskViewModel(UpdateViewCommand, User, Sug, Suggestion, Tutorial));
        }

        public void AcceptPendingRequest()
        {
            if (OrganizierTasks.Count == 0)
            {
                MessageBox.Show("Morate dodati bar jedan zadatak na ponudu!");
                return;
            }
            Sug.RequestState = RequestState.Accepted;
            MessageBox.Show("Prihvatili ste zahtev!\nTutorijal se ovde završava!");
            TutorialWindow.CloseTutorial.Execute("");
        }
    }
}
