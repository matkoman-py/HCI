using ReservationSystem.Commands;
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
                UpdateViewCommand.Execute("Profile");
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
