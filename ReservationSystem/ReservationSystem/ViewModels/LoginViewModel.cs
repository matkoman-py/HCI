using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Seeders;
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
                
                MessageBox.Show("Neispravna kombinacija korisničkog imena/lozinke!");
                return;
            }
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
                    OrganizerHomePage organizerHomePage = new OrganizerHomePage(user);
                    organizerHomePage.Show();
                    organizerHomePage.Topmost = true;
                    Application.Current.MainWindow.Hide();
                    //UpdateViewCommand.Execute(new OrganizierHomePageViewModel(UpdateViewCommand, user));
                    break;
                case Role.Administrator:
                    //administrator
                    AdminHomePage adminHomePage = new AdminHomePage(user);
                    adminHomePage.Show();
                    adminHomePage.Topmost = true;
                    Application.Current.MainWindow.Hide();
                    //UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand, user));//, new User()));
                    break;
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

