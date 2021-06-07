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
    public class AdminPartyTypeViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddFieldOfWorkCommand { get; set; }
        public ICollection<FieldOfWork> FieldsOfWork { get; set; }
        public ICommand BackCommand { get; set; }


        public AdminPartyTypeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            AddFieldOfWorkCommand = new DelegateCommand(AddFieldOfWork);
            FieldsOfWork = getFieldsOfWork();
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand)));
        }

        private ICollection<FieldOfWork> getFieldsOfWork()
        {
            using (var db = new ProjectDatabase())
            {
                return db.FieldsOfWork.ToList();
            }
        }

        private void AddFieldOfWork() 
        {

        }

    }
}
