using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Tutorial.ViewModel
{
    class CreateTaskViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public static ICommand SaveTaskCommand { get; set; }
        public User User { get; set; }
        public Suggestion Suggestion { get; set; }

        public PartyRequest Sug { get; set; }
        public OrganizierTask Task { get; set; }

        public CreateTaskViewModel(ICommand updateViewCommand, User user, PartyRequest sug, Suggestion suggestion)
        {
            Suggestion = suggestion;
            UpdateViewCommand = updateViewCommand;
            SaveTaskCommand = new DelegateCommand(saveTask);
            User = user;
            Sug = sug;
            Task = new OrganizierTask();
        }
 
        public void saveTask()
        {
            Suggestion.OrganizierTasks.Add(Task);
            UpdateViewCommand.Execute(new CreateSuggestionViewModel(UpdateViewCommand, User, Sug, Suggestion));
        }
    }
}
