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
    public class ChooseOrganisatorPageViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public User User { get; set; }
        public User SelectedOrganiser { get; set; }
        public PartyRequest PartyRequest { get; set; }
        private List<User> organisers { get; set; }

        public ICommand SearchCommand { get; set; }

        public string SrcAtr { get; set; }
        public List<User> Organisers
        {
            get { return organisers; }
            set
            {
                organisers = value;
                OnPropertyChanged("Organisers");
            }
        }
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
            Organisers = new List<User>();
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
            SearchCommand = new DelegateCommand(Search);

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
                MessageBox.Show("Izaberite organizatora");
                return;
            }
            PartyRequest.OrganiserId = SelectedOrganiser.Id;
            using (var db = new ProjectDatabase())
            {
                
                if (PartyRequest.Guests != null)
                {
                    for (int i = 0; i < PartyRequest.Guests.Count; i++)
                    {
                        PartyRequest.Guests[i] = db.Guests.Add(PartyRequest.Guests[i]);
                    }
                }
                var pt = db.PartyTypes.Where(p => p.Name == PartyRequest.PartyType.Name).First();
                PartyRequest.PartyType = pt;

                db.PartyRequests.Add(PartyRequest);
                db.SaveChanges();
            }
            MessageBox.Show("Uspešno ste kreirali zahtev.");
            UpdateViewCommand.Execute(new PendingRequestsViewModel(UpdateViewCommand,User));
        }

        public void RequestCreation()
        {
            //Console.WriteLine(SelectedOrganiser.Id);
            UpdateViewCommand.Execute(new RequesCreationViewModel(UpdateViewCommand, User));
        }

        public void Search()
        {
            if (SrcAtr == null) return;
            using (var db = new ProjectDatabase())
            {
                Organisers = db.Users
                        .Where(user => user.Role == Role.Organizier)
                        .Where(user => user.Name.Contains(SrcAtr) ||
                                        user.PhoneNumber.Contains(SrcAtr) ||
                                        user.Surname.Contains(SrcAtr) ||
                                        user.Email.Contains(SrcAtr)) 
                        .ToList();
            }
        }
    }
}
