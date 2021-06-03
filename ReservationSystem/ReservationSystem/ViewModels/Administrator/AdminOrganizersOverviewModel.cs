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
        public ICollection<User> Organizers { get; set; }
        public ICommand BackCommand { get; set; }


        public AdminOrganizersOverviewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToAddOrganizerCommand = new DelegateCommand(ToAddOrganizer);
            Organizers = getOrganizers();
            BackCommand = new DelegateCommand(() => 
                UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand)));
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
    }
}
