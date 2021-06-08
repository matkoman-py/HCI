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
        public AddOfferViewCommand AddOfferCommand { get; set; }
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
            using (var db = new ProjectDatabase())
            {
                FieldOfWorkOptions = db.FieldsOfWork.ToList();
            }
            EditAssociatesCommand = new DelegateCommand(UpdateAssociates);
            AddOfferCommand = new AddOfferViewCommand(UpdateViewCommand, this);
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
