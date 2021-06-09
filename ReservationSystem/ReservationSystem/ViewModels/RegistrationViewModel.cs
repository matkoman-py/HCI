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
    public class RegistrationViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public ICommand BackCommand { get; set; }
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
            BirthDate = DateTime.Today;
            BackCommand = new DelegateCommand(Login);
        }

        public void Login()
        {
            UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
        }
        private void Register()
        {
            if (Username == null || Password == null || Name == null || Surname == null || Email == null || BirthDate == null)
            {
                MessageBox.Show("Morate navesti sva polja!");
                
            }
            else
            {
                if (BirthDate.CompareTo(DateTime.Today) > 0)
                {
                    MessageBox.Show("Rođendan vam ne moze biti u budućnosti!");
                    return;
                }
                //ovde treba provera da li postoji korisnik sa tim korisnickim imenom u bazi, ali to ce biti nad onim ucitanim objektima
                using (var db = new ProjectDatabase())
                {
                    foreach(User u in db.Users)
                    {
                        if(u.Username == Username)
                        {
                            MessageBox.Show("Korisničko ime nije jedinstveno!");
                            return;
                        }
                    }
                    db.Users.Add(new User(Username, Password, Email, Name, Surname, BirthDate, Role.Customer));
                    db.SaveChanges();
                    MessageBox.Show("Uspešna registracija, ulogujte se..");
                    UpdateViewCommand.Execute(new LoginViewModel(UpdateViewCommand));
                }
            }

            

        }
    }
}
