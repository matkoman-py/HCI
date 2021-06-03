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
    class AdminAssociatesViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand ToAddAssociatesCommand { get; set; }
        public ICollection<Associate> Associates { get; set; }
        public ICommand BackCommand { get; set; }


        public AdminAssociatesViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToAddAssociatesCommand = new DelegateCommand(ToAddAssociate);
            Associates = getAssociates();
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand)));
        }

        private ICollection<Associate> getAssociates()
        {
            using (var db = new ProjectDatabase())
            {
                return db.Associates.ToList();
            }
        }

        public void ToAddAssociate()
        {
            UpdateViewCommand.Execute(new AddAssociatesViewModel(UpdateViewCommand));
        }
    }
}
