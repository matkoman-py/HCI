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
        public User User { get; set; }
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
            ChooseOrganisatorPageCommand = new DelegateCommand(ChooseOrganisatorPage);
            User = user;
            using (var db = new ProjectDatabase()) {
                PartyTypes = db.PartyTypes.ToList();
            }
            PartyRequest = new PartyRequest();
            PartyRequest.RequestState = RequestState.Pending;
            PartyRequest.CreatorId = user.Id;
        }
        public void UserHomePage()
        {
            UpdateViewCommand.Execute(new UserHomePageViewModel(User));
        }

        public void ChooseOrganisatorPage()
        {
            UpdateViewCommand.Execute(new ChooseOrganisatorPageViewModel(UpdateViewCommand, User, PartyRequest));
        }
    }
}
