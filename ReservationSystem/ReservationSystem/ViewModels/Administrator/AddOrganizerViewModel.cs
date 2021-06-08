using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AddOrganizersViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddOrganizerCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }

        public AddOrganizersViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            AddOrganizerCommand = new DelegateCommand(AddOrganizer);
            Birthday = DateTime.Now;
            BackCommand = new DelegateCommand(() => 
                UpdateViewCommand.Execute(new AdminOrganizersOverviewModel(UpdateViewCommand)));
        }

        private void AddOrganizer() 
        {
            using (var db = new ProjectDatabase()) 
            {
                try
                {
                    User user = new User
                    {
                        Name = Name,
                        Surname = Surname,
                        Email = Email,
                        Password = Password,
                        Username = Username,
                        PhoneNumber = PhoneNumber,
                        Birthday = Birthday,
                        Role = Role.Organizier,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AdminOrganizersOverviewModel(UpdateViewCommand));
                }
                catch
                {
                    Console.WriteLine("Can't add organizer!");
                }
                
            }
        }
    }
}
