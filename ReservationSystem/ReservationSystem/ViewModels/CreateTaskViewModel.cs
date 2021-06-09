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
    public class CreateTaskViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand CreateSuggestionViewCommand { get; set; }

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
            CreateSuggestionViewCommand = new DelegateCommand(CreateSuggestionView);
            User = user;
            Sug = sug;
            Task = new OrganizierTask();
        }
        public void CreateSuggestionView()
        {
            UpdateViewCommand.Execute(new CreateSuggestionViewViewModel(UpdateViewCommand, User, Sug));
        }
        public void saveTask()
        {
            using (var db = new ProjectDatabase())
            {
                OrganizierTask task = new OrganizierTask();
                task.Comment = Task.Comment;
                task.Description = Task.Description;
                task.Name = Task.Name;
                task.SuggestionId = Suggestion.Id;
                Console.WriteLine(task.SuggestionId);
                db.OrganizierTasks.Add(task);
                db.SaveChanges();
            }
            UpdateViewCommand.Execute(new CreateSuggestionViewViewModel(UpdateViewCommand, User, Sug));
        }
    }
}
