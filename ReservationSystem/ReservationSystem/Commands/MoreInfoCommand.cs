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
            if (sug.RequestState == RequestState.Accepted || sug.RequestState == RequestState.Rejected)
            {
                Console.WriteLine("idi obradjene");
                //return getProcessed();

            }
            else if (sug.RequestState == RequestState.Pending)
            {
                UpdateViewCommand.Execute(new PendingRequestOverview(UpdateViewCommand, sug));
                Console.WriteLine("idi neobradjene");
                //return getPending();
            }
            else
            {
                Console.WriteLine("idi  aktivne");
                //return getActive();
            }
        }

        public MoreInfoCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
