using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
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
        public DelegateCommand AddOfferCommand { get; set; }
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
            Associate.FieldOfWork = FieldOfWorkOptions.Find(field => field.Id == Associate.FieldOfWorkId);
        }

        private void Setup(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            using (var db = new ProjectDatabase())
            {
                FieldOfWorkOptions = db.FieldsOfWork.ToList();
            }
            EditAssociatesCommand = new DelegateCommand(UpdateAssociates);
            AddOfferCommand = new DelegateCommand(GoToAddOffer);
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand)));
        }

        public void GoToAddOffer()
        {
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new AddOfferViewModel(UpdateViewCommand, Associate));
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
