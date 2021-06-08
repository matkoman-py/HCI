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
    public class AdminOrganizersOverviewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand ToAddOrganizerCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private ICollection<User> organizers;
        public ICollection<User> Organizers 
        {
            get { return organizers; }
            set 
            { 
                organizers = value;
                OnPropertyChanged("Organizers");
            }
        }
        public string SearchQuery { get; set; }

        public AdminOrganizersOverviewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToAddOrganizerCommand = new DelegateCommand(ToAddOrganizer);
            SearchCommand = new DelegateCommand(Search);
            Organizers = getOrganizers();
        }

        private ICollection<User> getOrganizers() 
        {
            using (var db = new ProjectDatabase())
            {
                return db.Users.Where(user => user.Role == Role.Organizier).ToList();
            }
        }

        public void ToAddOrganizer()
        {
            UpdateViewCommand.Execute(new AddOrganizersViewModel(UpdateViewCommand));
        }

        private void Search()
        {
            if (String.IsNullOrEmpty(SearchQuery))
            {
                Organizers = getOrganizers();
            }
            else
            {
                using (var db = new ProjectDatabase())
                {
                    Organizers = db.Users
                        .Where(user => user.Role == Role.Organizier)
                        .Where(user => user.Name.Contains(SearchQuery) ||
                                        user.PhoneNumber.Contains(SearchQuery) ||
                                        user.Surname.Contains(SearchQuery) ||
                                        user.Email.Contains(SearchQuery))
                        .ToList();
                }
            }
        }
    }
}
