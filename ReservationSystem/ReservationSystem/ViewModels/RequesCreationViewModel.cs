using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class RequesCreationViewModel : BaseViewModel
    {
        public PartyRequest PartyRequest { get; set; }
        /*
         PartyType PartyType
         int Budget
         string Place
         DateTime Time
         int Capacity
         bool IsBudgetFlexible
         string PartyTheme
         string Description
         RequestState RequestState
         int CreatorId
        */
        public List<PartyType> PartyTypes { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public static ICommand SetGuestsCommand { get; set; }
        public User User { get; set; }
        public string Budget { get; set; }
        public string Capacity { get; set; }
        public DateTime Time { get; set; }
        public ICommand UserHomePageCommand
        {
            get; set;
        }

        public ICommand ChooseOrganisatorPageCommand
        {
            get; set;
        }

        public RequesCreationViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            SetGuestsCommand = new DelegateCommand(SetGuests);
            ChooseOrganisatorPageCommand = new DelegateCommand(ChooseOrganisatorPage);
            User = user;
            using (var db = new ProjectDatabase()) {
                PartyTypes = db.PartyTypes.ToList();
            }
            PartyRequest = new PartyRequest();
            PartyRequest.RequestState = RequestState.Pending;
            PartyRequest.CreatorId = user.Id;
            PartyRequest.Date = DateTime.Today;
            Time = DateTime.Now;
        }
        public void UserHomePage()
        {
            UpdateViewCommand.Execute(new UserHomePageViewModel(User));
        }

        public void ChooseOrganisatorPage()
        {
            if(PartyRequest.Date.CompareTo(DateTime.Today) < 0)
            {
                MessageBox.Show("Ne možete izabrati datum u prošlosti!");
                return;
            }
            if(string.IsNullOrEmpty(PartyRequest.PartyTheme.Trim()) || string.IsNullOrEmpty(PartyRequest.Place.Trim()) || string.IsNullOrEmpty(PartyRequest.Description.Trim()) || PartyRequest.PartyType == null)
            {
                MessageBox.Show("Morate uneti sve podatke!");
                return;
            }
            
            int budget;
            bool success = Int32.TryParse(Budget, out budget);
            if (!success)
            {
                MessageBox.Show("Morate uneti brojevnu vrednost za budzet!");
                return;
            }
            int capacity;
            success = Int32.TryParse(Capacity, out capacity);
            if (!success)
            {
                MessageBox.Show("Morate uneti brojevnu vrednost za kapacitet!");
                return;
            }
            PartyRequest.Budget = budget;
            PartyRequest.Capacity = capacity;

            var combinedDateTime = PartyRequest.Date.AddTicks(Time.TimeOfDay.Ticks);
            PartyRequest.Date = combinedDateTime;
            
            UpdateViewCommand.Execute(new ChooseOrganisatorPageViewModel(UpdateViewCommand, User, PartyRequest));
        }

        private Object SetGuests(Object obj) 
        {
            PartyRequest.Guests = (List<Guest>)obj;
            return obj;
        }
    }
}
