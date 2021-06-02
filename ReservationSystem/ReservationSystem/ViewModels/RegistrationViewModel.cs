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
    public class RegistrationViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public RegistrationViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            RegisterCommand = new DelegateCommand(Register);
        }

        private void Register()
        {
            if (Username == null || Password == null || Name == null || Surname == null || Email == null || BirthDate == null)
            {
                Console.WriteLine("All atributes must be specified!");
            }
            else
            {
                //ovde treba provera da li postoji korisnik sa tim korisnickim imenom u bazi, ali to ce biti nad onim ucitanim objektima
                using (var db = new ProjectDatabase())
                {
                    db.Users.Add(new User(Username, Password, Email, Name, Surname, BirthDate, Role.Customer));
                    db.SaveChanges();
                }
            }

            Console.WriteLine("Uspesna registracija, ulogujte se..");
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));//, new User()));

        }
    }
}
