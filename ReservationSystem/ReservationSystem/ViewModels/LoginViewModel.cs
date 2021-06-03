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


    public class LoginViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand
        {
            get; set;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            LoginCommand = new DelegateCommand(Login);
        }

        public void Login() 
        {
            if (CheckCredentials())
            {
                /*
                using (var db = new ProjectDatabase())
                {
                    db.Users.Add(new User("pera", "pera", "Pera", "Peric", "gmail@yahoo.uns.ac.rs",new DateTime(1999, 9, 5), Role.Customer));
                    db.Users.Add(new User("mika", "mika", "Mika", "Mikic", "gmail@yahoo.uns.ac.rs", new DateTime(1998, 9, 5), Role.Administrator));
                    db.Users.Add(new User("zika", "zika", "Zika", "Zikic", "gmail@yahoo.uns.ac.rs", new DateTime(1997, 9, 5), Role.Organizier));
                    db.SaveChanges();
                }
                */
                UpdateViewCommand.Execute(new UserHomePageViewModel(UpdateViewCommand));
            }
            else 
            {
                Console.WriteLine("nemas pojma");
            }
        }

        public Boolean CheckCredentials() 
        {
            if (Username == "pera" && Password == "pass") 
            {
                return true;
            }
            return false;
        }
    }
}
