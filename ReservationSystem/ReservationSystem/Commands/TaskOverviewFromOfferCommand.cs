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
    public class TaskOverviewFromOfferCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ICommand UpdateViewCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Offer sug = (Offer)parameter;
            //PRONADJI U DB KOJI ORGANIZIERTASK IMA OVAJ OFFER U SEBI I TOG POSALJI NAZAD
            
            UpdateViewCommand.Execute(new TaskOverviewViewModel(UpdateViewCommand, new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        new Offer(null,"Ime",100,"Opasna ponuda1", "nema slike"),
                        new Offer(null,"Ime",150,"Opasna ponuda2", "ima slike"),
                        new Offer(null,"Ime",200,"Opasna ponuda3", "nema slike"),

                    }, false, "kurcina", UserApproval.Neobradjen)));
        }

        public TaskOverviewFromOfferCommand(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
