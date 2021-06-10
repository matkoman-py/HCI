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
    public class CreateNewAssociateViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;

        public User User { get; set; }
        public Associate Associate { get; set; }
        public ICommand BackCommand { get; set; }
        public static ICommand AddAssociatesCommand { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public CreateNewAssociateViewModel(ICommand updateViewCommand, User user)
        {
            UpdateViewCommand = updateViewCommand;
            using(var db = new ProjectDatabase())
            {
                FieldOfWorkOptions = db.FieldsOfWork.ToList();
            }
            
            AddAssociatesCommand = new DelegateCommand(AddAssociates);
            User = user;
            BackCommand = new DelegateCommand(() => UpdateViewCommand.Execute(new AssociateOverviewViewModel(UpdateViewCommand,User)));
            Associate = new Associate();
        }
        private void AddAssociates()
        {
            if(string.IsNullOrEmpty(Associate.Address) || string.IsNullOrEmpty(Associate.Description) || string.IsNullOrEmpty(Associate.Name) || Associate.FieldOfWork == null)
            {
                MessageBox.Show("Morate uneti sva polja!");
                return;
            }
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Associates.Add(Associate);
                    db.SaveChanges();
                    MessageBox.Show("Uspešno ste dodali saradnika.");
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
