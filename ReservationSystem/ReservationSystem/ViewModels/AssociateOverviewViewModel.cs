using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class AssociateOverviewViewModel : BaseViewModel
    {
        public List<Associate> Associates { get; set; }

        public Associate SelectedAssociate { get; set; }
        public ICommand UpdateViewCommand
        {
            get; set;
        }
        public ICommand AddNewOfferForAssociateCommand
        {
            get; set;
        }
        public ICommand AddNewAssociateCommand
        {
            get; set;
        }
        public AssociateOverviewViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            SelectedAssociate = null;
            Associates = getAssociates();
            AddNewOfferForAssociateCommand = new DelegateCommand(AddNewOfferForAssociate);
            AddNewAssociateCommand = new DelegateCommand(AddNewAssociate);
        }

        public List<Associate> getAssociates()
        {
            List<Associate> associates = new List<Associate>();
            using(var db = new ProjectDatabase())
            {
                associates = db.Associates.ToList();
            }
            return associates;
        }

        public void AddNewOfferForAssociate()
        {
            if (SelectedAssociate != null)
            {
                Console.WriteLine(SelectedAssociate.Address);
                UpdateViewCommand.Execute(new CreateNewOfferViewModel(UpdateViewCommand, SelectedAssociate));
            }
            else
            {
                MessageBox.Show("Niste izabrali saradnika za kog se kreira ponuda!");
            }
        }
        public void AddNewAssociate()
        {
            
                UpdateViewCommand.Execute(new CreateNewAssociateViewModel(UpdateViewCommand));
            
        }
    }
}
