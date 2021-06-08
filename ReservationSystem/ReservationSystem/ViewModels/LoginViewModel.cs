using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.ViewModels.Administrator;
using ReservationSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{


    public class LoginViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        static public ICommand RegistrationCommand { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            LoginCommand = new DelegateCommand(Login);
            RegistrationCommand = new DelegateCommand(Register);
        }

        public void Login()
        {
            User user = findUser();
            if (user == null)
            {
                Console.WriteLine("Netacni kredencijali!");
                using (var db = new ProjectDatabase())
                {
                    db.Users.Add(new User("pera", "pera", "peragmajl", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Customer));
                    db.Users.Add(new User("mika", "mika", "mikagmajl", "Mika", "Mikic", new DateTime(1998, 9, 5), Role.Administrator));
                    db.Users.Add(new User("zika", "zika", "zikagmajl", "Zika", "Zikic", new DateTime(1997, 9, 5), Role.Organizier));

                    Associate associate = new Associate("Kod Jove", "Kumanovska 2, Zrenjanin", "Nesto nesto nesto", FieldOfWork.Restaurant);
                    db.Associates.Add(associate);

                    Offer of1 = new Offer(associate, "Ime", 100, "Opasna ponuda1", "nema slike");
                    db.Offers.Add(of1);
                    Offer of2 = new Offer(associate, "Ime", 150, "Opasna ponuda2", "ima slike");
                    db.Offers.Add(of2);
                    Offer of3 = new Offer(associate, "Ime", 200, "Opasna ponuda3", "nema slike");
                    db.Offers.Add(of3);
                    OrganizierTask or1 = new OrganizierTask("Zadatak1", "Prvi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "kurcina", UserApproval.Neobradjen);

                    OrganizierTask or2 = new OrganizierTask("Zadatak2", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

                    OrganizierTask or3 = new OrganizierTask("Zadatak3", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

                    OrganizierTask ora1 = new OrganizierTask("Zadatak11", "Prvi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3

                    }, false, "kurcina", UserApproval.Neobradjen);

                    OrganizierTask ora2 = new OrganizierTask("Zadatak22", "Drugi zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, false, "kurcina", UserApproval.Neobradjen);

                    OrganizierTask ora3 = new OrganizierTask("Zadatak33", "Treci zadatak", new List<Offer>(){
                        of1,
                        of2,
                        of3


                    }, true, "kurcina", UserApproval.Neobradjen);

                    db.OrganizierTasks.Add(or1);
                    db.OrganizierTasks.Add(or2);
                    db.OrganizierTasks.Add(or3);
                    PartyRequest pr1 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Zezanje", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr2 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Kanada", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr3 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Banana split", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr4 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "BOBI I COBI", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr5 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Tekela", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr6 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Pakle", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr7 = new PartyRequest(PartyType.Birthday, 550, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak1", "Duvanje", RequestState.Pending, 1);
                    PartyRequest pr8 = new PartyRequest(PartyType.Anniversary, 600, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak2", "Duvanje", RequestState.Accepted, 1);
                    PartyRequest pr9 = new PartyRequest(PartyType.Other, 700, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak3", "Duvanje", RequestState.Active, 1);
                    PartyRequest pr10 = new PartyRequest(PartyType.Other, 700, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak4", "Duvanje", RequestState.Rejected, 1);
                    db.PartyRequests.Add(pr1);
                    db.PartyRequests.Add(pr2);
                    db.PartyRequests.Add(pr3);
                    db.PartyRequests.Add(pr4);
                    db.PartyRequests.Add(pr5);
                    db.PartyRequests.Add(pr6);
                    db.PartyRequests.Add(pr7);
                    db.PartyRequests.Add(pr8);
                    db.PartyRequests.Add(pr9);
                    db.PartyRequests.Add(pr10);

                    Suggestion sug = new Suggestion(new List<OrganizierTask>(){
                    or1,or2,or3
                }, "MASU JAK PREDLOG1", pr1);
                    Suggestion sug2 = new Suggestion(new List<OrganizierTask>(){
                    or1,or2,or3
                }, "MASU JAK PREDLOG1", pr1);

                    db.Suggestions.Add(sug2);
                    db.Suggestions.Add(sug);
                    db.SaveChanges();
                }

            }
            else
            {
                switch (user.Role)
                {
                    case Role.Customer:
                        //customer
                        //UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand, user));//, new User()));
                        UserHomePage userHomePage = new UserHomePage(user);
                        userHomePage.Show();
                        userHomePage.Topmost = true;
                        Application.Current.MainWindow.Hide();
                        break;
                    case Role.Organizier:
                        //organizier
                        //UpdateViewCommand.Execute(new RequestsOverviewViewModel(UpdateViewCommand, user));//, new User()));
                        UpdateViewCommand.Execute(new OrganizierHomePageViewModel(UpdateViewCommand, user));
                        break;
                    case Role.Administrator:
                        //administrator
                        UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand, user));//, new User()));
                        break;
                }
            }
        }

        public void Register()
        {
            UpdateViewCommand.Execute(new RegistrationViewModel(UpdateViewCommand));//, new User()));
        }

        public User findUser()
        {
            //verovatno ce biti neki globalni objekat u koji cemo ucitati na pocetku sve entitete, da ne bi pristupali bazi pri svakoj proveri
            using (var db = new ProjectDatabase())
            {
                foreach (User user in db.Users)
                {
                    if (user.Username.Equals(Username) && user.Password.Equals(Password))
                        return user;
                }
            }
            return null;
        }
    }
}
