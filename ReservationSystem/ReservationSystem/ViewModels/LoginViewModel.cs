﻿using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    db.Users.Add(new User("pera", "pera","peragmajl", "Pera", "Peric", new DateTime(1999, 9, 5), Role.Customer));
                    db.Users.Add(new User("mika", "mika", "mikagmajl", "Mika", "Mikic", new DateTime(1998, 9, 5), Role.Administrator));
                    db.Users.Add(new User("zika", "zika", "zikagmajl", "Zika", "Zikic", new DateTime(1997, 9, 5), Role.Organizier));

                    Offer of1 = new Offer(null, 100, "Opasna ponuda1", "nema slike");
                    db.Offers.Add(of1);
                    Offer of2 = new Offer(null, 150, "Opasna ponuda2", "ima slike");
                    db.Offers.Add(of2);
                    Offer of3 = new Offer(null, 200, "Opasna ponuda3", "nema slike");
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
                    db.OrganizierTasks.Add(or1);
                    db.OrganizierTasks.Add(or2);
                    db.OrganizierTasks.Add(or3);
                    PartyRequest pr = new PartyRequest(PartyType.Birthday, 500, "Mite cenica", new DateTime(1997, 9, 5), 1999, false, "Lepak", "Duvanje", RequestState.Accepted, 1);
                    db.PartyRequests.Add(pr);
                    Suggestion sug = new Suggestion(new List<OrganizierTask>(){
                    or1,or2,or3
                }, "MASU JAK PREDLOG1", pr);

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
                        UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand, user));//, new User()));
                        break;
                    case Role.Organizier:
                        //organizier
                        UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand, user));//, new User()));
                        break;
                    case Role.Administrator:
                        //administrator
                        UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand, user));//, new User()));
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
