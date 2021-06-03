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
    public class DataUpdateViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string password { get; set; }
        public string name_copy { get; set; }
        public string surname_copy { get; set; }
        public string username_copy { get; set; }
        public string email_copy { get; set; }
        public DateTime birthday_copy { get; set; }
        public string password_copy { get; set; }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand ProfileCancelCommand
        {
            get; set;
        }

        public ICommand ProfileSaveCommand
        {
            get; set;
        }

        public DataUpdateViewModel(ICommand updateViewCommand, string name, string surname,string username, string email, DateTime birthday, string password)
        {
            UpdateViewCommand = updateViewCommand;
            ProfileCancelCommand = new DelegateCommand(ProfileCancel);
            ProfileSaveCommand = new DelegateCommand(ProfileSave);
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
            this.email = email;
            this.birthday = birthday;

            name_copy = name;
            surname_copy = surname;
            username_copy = username;
            password_copy = password;
            email_copy = email;
            birthday_copy = birthday;
        }
        public void ProfileCancel()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, name_copy, surname_copy, username_copy, email_copy, birthday_copy, password_copy));
        }
        public void ProfileSave()
        {
            using (var db = new ProjectDatabase())
            {
                foreach (User user in db.Users.ToList())
                {
                    if (user.Username.Equals(username))
                    {
                        user.Name = name;
                        user.Surname = surname;
                        user.Email = email;
                        user.Birthday = birthday;
                        user.Password = password;
                        db.SaveChanges();
                        break;
                    }
                }
            }
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, name, surname, username, email, birthday, password));
        }
    }
}
