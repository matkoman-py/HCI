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

        public User User { get; set; }

        public User UserCopy {get;set;}

        public ICommand UpdateViewCommand { get; set; }

        public ICommand ProfileCancelCommand
        {
            get; set;
        }

        public ICommand ProfileSaveCommand
        {
            get; set;
        }

        public DataUpdateViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            ProfileCancelCommand = new DelegateCommand(ProfileCancel);
            ProfileSaveCommand = new DelegateCommand(ProfileSave);
            UserCopy = new User(user);
            User = user;
            
        }
        public void ProfileCancel()
        {
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, UserCopy));
        }
        public void ProfileSave()
        {
            if (User.Birthday.CompareTo(DateTime.Today) > 0)
            {
                MessageBox.Show("Ne mozete se roditi u buducnost xD");
                return;
            }
            using (var db = new ProjectDatabase())
            {
                foreach (User user in db.Users.ToList())
                {
                    if (user.Username.Equals(User.Username))
                    {
                        user.Name = User.Name;
                        user.Surname = User.Surname;
                        user.Email = User.Email;
                        user.Birthday = User.Birthday;
                        user.Password = User.Password;
                        db.SaveChanges();
                        break;
                    }
                }
            }
            UpdateViewCommand.Execute(new ProfileViewModel(UpdateViewCommand, User));
        }
    }
}
