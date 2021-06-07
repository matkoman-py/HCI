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
    public class ChooseOrganisatorPageViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public User User { get; set; }
        public User SelectedOrganiser { get; set; }
        public PartyRequest PartyRequest { get; set; }
        public List<Object> Organisers { get; set; }
        public ICommand RequestCreationCommand
        {
            get; set;
        }

        public ICommand UserHomePageCommand
        {
            get; set;
        }

        public ChooseOrganisatorPageViewModel(ICommand updateViewCommand, User user,PartyRequest partyRequest)
        {
            UpdateViewCommand = updateViewCommand;
            RequestCreationCommand = new DelegateCommand(RequestCreation);
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            User = user;
            PartyRequest = partyRequest;
            Organisers = new List<Object>();
            /*
            using (var db = new ProjectDatabase())
            {
                db.Users.Add(new User("pera", "pera","mail", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Organizier));
                db.Users.Add(new User("mika", "mika", "mail", "Mika", "Mikic", new DateTime(1998, 9, 5), Role.Organizier));
                db.Users.Add(new User("zika", "zika", "mail", "Zika", "Zikic", new DateTime(1997, 9, 5), Role.Organizier));
                Organisers.Add(new User("pera", "pera", "mail", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Organizier));
                db.SaveChanges();
            }
            */
            fillOrganisers();
        }
        public void fillOrganisers()
        {
            using (var db = new ProjectDatabase())
            {
                foreach(User user in db.Users)
                {
                    if(user.Role.Equals(Role.Organizier))
                        Organisers.Add(user);
                }
            }
        }
        public void UserHomePage()
        {
            if(SelectedOrganiser == null)
            {
                Console.WriteLine("Izaberite organizatora");
                return;
            }
            PartyRequest.OrganiserId = SelectedOrganiser.Id;
            using (var db = new ProjectDatabase())
            {
                db.PartyRequests.Add(PartyRequest);
                db.SaveChanges();
            }
            UpdateViewCommand.Execute(new UserHomePageViewModel(User));
        }

        public void RequestCreation()
        {
            //Console.WriteLine(SelectedOrganiser.Id);
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand, User));
        }
    }
}
