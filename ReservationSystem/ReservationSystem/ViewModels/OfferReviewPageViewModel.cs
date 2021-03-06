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
    public class OfferReviewPageViewModel : BaseViewModel
    {
        public Offer Offer { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public ICommand TaskOverviewFromOfferCommand { get; set; }

        public ICommand BackCommand { get; set; }
        public int OrganizierTaskId { get; set; }
        public OfferReviewPageViewModel(ICommand updateViewCommand, Offer suggestion, int organizierTaskId)
        {

            UpdateViewCommand = updateViewCommand;
            //TaskOverviewFromOfferCommand = new TaskOverviewFromOfferCommand(UpdateViewCommand);
            BackCommand = new DelegateCommand(Back);
            Offer = suggestion;
            OrganizierTaskId = organizierTaskId;
        }
        public void Back()
        {
            OrganizierTask ot;
            using(var db = new ProjectDatabase())
            {
                ot = db.OrganizierTasks.Include("Offers").Where(o => o.Id == OrganizierTaskId).First();
            }
            UpdateViewCommand.Execute(new TaskOverviewViewModel(UpdateViewCommand, ot));
        }

    }
}
