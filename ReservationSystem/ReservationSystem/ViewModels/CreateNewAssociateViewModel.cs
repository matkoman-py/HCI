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

        public Associate Associate { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand AddAssociatesCommand { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public CreateNewAssociateViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            FieldOfWorkOptions = Enum.GetValues(typeof(FieldOfWork)).Cast<FieldOfWork>().ToList();
            AddAssociatesCommand = new DelegateCommand(AddAssociates);
            
            BackCommand = new DelegateCommand(() => UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand)));
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
                    UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand));
                }
                catch
                {
                    Console.WriteLine("Can't add associate!");
                }

            }
        }
    }
}
