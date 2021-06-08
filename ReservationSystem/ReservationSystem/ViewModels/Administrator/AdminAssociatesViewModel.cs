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
        public ICommand SearchCommand { get; set; }
        public EditAssociateViewCommand ToEditAssociatesCommand { get; set; }

        private ICollection<Associate> associates;
        public ICollection<Associate> Associates
        {
            get { return associates; }
            set
            {
                associates = value;
                OnPropertyChanged("Associates");
            }
        }
        public string SearchQuery { get; set; }
        public ICommand BackCommand { get; set; }
        public AdminAssociatesViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            ToAddAssociatesCommand = new DelegateCommand(ToAddAssociate);
            SearchCommand = new DelegateCommand(Search);
            ToEditAssociatesCommand = new EditAssociateViewCommand(UpdateViewCommand);
            Associates = getAssociates();
            BackCommand = new DelegateCommand(() =>
                UpdateViewCommand.Execute(new AdminPageViewModel(UpdateViewCommand)));
        }

        private ICollection<Associate> getAssociates()
        {
            using (var db = new ProjectDatabase())
            {
                return db.Associates.Include("FieldOfWork").Include("Offers").ToList();
            }
        }

        private void Search()
        {
            if (String.IsNullOrEmpty(SearchQuery))
            {
                Associates = getAssociates();
            }
            else
            {
                using (var db = new ProjectDatabase())
                {
                    Associates = db.Associates.Include("FieldOfWork").Include("Offers")
                        .Where(a => a.Name.Contains(SearchQuery) ||
                                        a.Address.Contains(SearchQuery) ||
                                        a.Description.Contains(SearchQuery) ||
                                        a.FieldOfWork.Name.Contains(SearchQuery))
                        .ToList();
                }
            }
        }

        public void ToAddAssociate()
        {
            UpdateViewCommand.Execute(new AddAssociatesViewModel(UpdateViewCommand));
        }
    }
}
