using ReservationSystem.Models;
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
                Console.WriteLine("idi obradjene");
                //return getProcessed();

            }
            else if (sug.RequestState == RequestState.Pending)
            {
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
