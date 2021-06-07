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
    public class CreateNewAssociateViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;

        public User User { get; set; }
        public Associate Associate { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand AddAssociatesCommand { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public CreateNewAssociateViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            FieldOfWorkOptions = Enum.GetValues(typeof(FieldOfWork)).Cast<FieldOfWork>().ToList();
            AddAssociatesCommand = new DelegateCommand(AddAssociates);
            User = user;
            BackCommand = new DelegateCommand(() => UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand,User)));
            Associate = new Associate();
        }
        private void AddAssociates()
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Associates.Add(Associate);
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand, User));
                }
                catch
                {
                    Console.WriteLine("Can't add associate!");
                }

            }
        }
    }
}
