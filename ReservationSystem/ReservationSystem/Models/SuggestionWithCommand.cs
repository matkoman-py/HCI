using ReservationSystem.Commands;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Models
{
    public class SuggestionWithCommand
    {
        public Suggestion Suggestion { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand RequestViewCommand
        {
            get; set;
        }
        public SuggestionWithCommand(Suggestion suggestion, ICommand updateViewCommand)
        {
            RequestViewCommand = new DelegateCommand(RequestView);
            Suggestion = suggestion;
            UpdateViewCommand = updateViewCommand;
        }
        public void RequestView()
        {
            UpdateViewCommand.Execute(new RequestViewViewModel(UpdateViewCommand, Suggestion));
        }
    }
}
