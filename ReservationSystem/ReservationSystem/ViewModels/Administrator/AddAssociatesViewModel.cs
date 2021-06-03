using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    internal class AddAssociatesViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddAssociatesCommand { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public FieldOfWork FieldOfWork { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public string Offers { get; set; }

        public AddAssociatesViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            FieldOfWorkOptions = Enum.GetValues(typeof(FieldOfWork)).Cast<FieldOfWork>().ToList();
            AddAssociatesCommand = new DelegateCommand(AddAssociates);
        }

        private void AddAssociates() 
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    Associate associate = new Associate
                    {
                        Name = Name,
                        Address = Address,
                        Description = Description,
                        FieldOfWork = FieldOfWork,
                    };
                    db.Associates.Add(associate);
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand));
                }
                catch
                {
                    Console.WriteLine("Can't add associates!");
                }

            }
        }
    }
}