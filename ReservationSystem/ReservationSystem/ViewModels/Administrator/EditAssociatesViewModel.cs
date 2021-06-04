using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class EditAssociatesViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand EditAssociatesCommand { get; set; }
        public EditOfferViewCommand EditOfferCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public Associate Associate { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public EditAssociatesViewModel(ICommand updateViewCommand)
        {
            Setup(updateViewCommand);
            Associate = new Associate();
        }

        public EditAssociatesViewModel(ICommand updateViewCommand, Associate associate)
        {
            Setup(updateViewCommand);
            Associate = associate;
        }

        private void Setup(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            FieldOfWorkOptions = Enum.GetValues(typeof(FieldOfWork)).Cast<FieldOfWork>().ToList();
            EditAssociatesCommand = new DelegateCommand(UpdateAssociates);
            EditOfferCommand = new EditOfferViewCommand(UpdateViewCommand);
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand)));
        }

        private void UpdateAssociates()
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Entry(Associate).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand));
                }
                catch
                {
                    Console.WriteLine("Can't update associate!");
                }

            }
        }
    }
}
