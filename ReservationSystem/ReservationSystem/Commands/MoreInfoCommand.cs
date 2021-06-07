using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Commands
{
    public class MoreInfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PartyRequest sug = (PartyRequest)parameter;
            //UpdateViewCommand.Execute(new TaskOverviewViewModel(UpdateViewCommand, sug));
            if (sug.RequestState == RequestState.Accepted || sug.RequestState == RequestState.Rejected)
            {
                if(sug.RequestState == RequestState.Accepted)
                {
                    UpdateViewCommand.Execute(new AcceptedRequestOverviewViewModel(UpdateViewCommand, sug));
                }
                if (sug.RequestState == RequestState.Rejected)
                {
                    UpdateViewCommand.Execute(new RejectedRequestOverviewViewModel(UpdateViewCommand, sug));
                }

            }
            else if (sug.RequestState == RequestState.Pending)
            {
                Console.WriteLine("idi neobradjene");
                //return getPending();
            }
            else
            {
                Console.WriteLine("idi  aktivne");
                UpdateViewCommand.Execute(new ActiveRequestOverviewViewModel(UpdateViewCommand, sug));
            }
        }

        public MoreInfoCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
