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
    public class OfferReviewOrganizerViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public Offer Offer { get; set; }
        public int OrganizierTaskId { get; set; }
        public ICommand BackCommand { get; set; }
        public OfferReviewOrganizerViewModel(ICommand updateViewCommand, Offer suggestion, int organizierTaskId)
        {

            UpdateViewCommand = updateViewCommand;
            Offer = suggestion;
            BackCommand = new DelegateCommand(Back);
            OrganizierTaskId = organizierTaskId;
        }

        public void Back()
        {
            using(var db = new ProjectDatabase())
            {
                OrganizierTask ot;
                ot = db.OrganizierTasks.Include("Offers").Where(o => o.Id == OrganizierTaskId).First();
                if (ot.IsDone)
                {
                    UpdateViewCommand.Execute(new ResolvedTaskOverviewViewModel(UpdateViewCommand, ot));
                }
                else
                {
                    UpdateViewCommand.Execute(new ActiveTaskOverviewViewModel(UpdateViewCommand, ot));
                }
            }
        }
    }
}
